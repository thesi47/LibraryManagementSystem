using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Members.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Member
                {
                    MemberName = model.MemberName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };

                _context.Members.Add(entity);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.Members.FindAsync(id);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Member model)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = _context.Members.Find(id);
            return View(author);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Members.Find(id);
            if (author != null)
            {
                _context.Members.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
