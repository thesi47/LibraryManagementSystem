using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

    [Authorize]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleController(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public IActionResult Index()
    {
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (!await _roleManager.RoleExistsAsync(model.RoleName))
        {
            var result = await _roleManager.CreateAsync(
                new IdentityRole(model.RoleName));

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        else
        {
            ModelState.AddModelError("", "Role already exists.");
        }

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);

        if (role == null)
            return NotFound();

        await _roleManager.DeleteAsync(role);

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> AssignRole(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound();

        var model = new AssignRoleViewModel
        {
            UserId = user.Id,

            Roles = await _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToListAsync()
        };

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
    {
        if (!ModelState.IsValid)
        {

            model.Roles = await _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToListAsync();

            return View(model);
        }

        var user = await _userManager.FindByIdAsync(model.UserId);

        if (user == null)
            return NotFound();

        // Remove existing roles
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);

        // Assign new role
        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

        if (result.Succeeded)
            return RedirectToAction("Index","User");

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);


        model.Roles = await _roleManager.Roles
            .Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            })
            .ToListAsync();

        return View(model);
    }
}