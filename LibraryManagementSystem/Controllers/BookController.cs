using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Books.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Book
                {
                    Title = model.Title,
                    ISBN = model.ISBN,
                    Price = model.Price,
                    Quantity = model.Quantity
                };

                _context.Books.Add(entity);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.Books.FindAsync(id);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = _context.Books.Find(id);
            return View(author);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Books.Find(id);
            if (author != null)
            {
                _context.Books.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
