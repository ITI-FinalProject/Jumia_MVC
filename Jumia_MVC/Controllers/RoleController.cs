using FinalProject.MVC.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Controllers
{
    //[Authorize(Roles = UserRole.Admin)]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if (!ModelState.IsValid) return View("Index", await _roleManager.Roles.ToListAsync());

            var roleExist = await _roleManager.RoleExistsAsync(model.Name);

            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role Is Exist !!!");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(string  id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRole role)
        {
            var rolee = await _roleManager.FindByIdAsync(id);

            if (id != role.Id) return View("NotFound");

            //var roleExist = await _roleManager.RoleExistsAsync(role.Name);

            //if (await _roleManager.RoleExistsAsync(role.Name))
            //{
            //    ModelState.AddModelError("Name", "Role Is Exist !!!");
            //    return View("Index", await _roleManager.Roles.ToListAsync());
            //}

            rolee.Name = role.Name;

            await _roleManager.UpdateAsync(rolee);

            return RedirectToAction(nameof(Index));


        
        }

        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    View("NotFound");
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);

        }

    }
}
