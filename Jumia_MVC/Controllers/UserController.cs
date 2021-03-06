using FinalProject.MVC.Data.ViewModel;
using Jumia_MVC.Data.ViewModel;
using Jumia_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Controllers
{
    // [Authorize(Roles = "Admin")]

    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IHtmlLocalizer<UserController> _localizer;
        

        public UserController(
             UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager,
             IHtmlLocalizer<UserController> localizer
             )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _localizer = localizer;

        }
        public IActionResult Index()
        {
            var users =  _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Emaill = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToList();
            //  var res = await _context.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Create()
        {

            var roles = await _roleManager.Roles.Select(r => new RoleViewModel { RoleId = r.Id, RoleName = r.Name })
                        .ToListAsync();

            var viewModel = new AddUserViewModel
            {

                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", _localizer["selectOne"].ToString());
                return View(model);
            }

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", _localizer["Exists"].ToString());
                return View(model);
            }
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", _localizer["userExists"].ToString());
                return View(model);
            }
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                FullName = model.FullName,

            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Roles", item.Description);

                }
                return View(model);

            }
            await _userManager.AddToRolesAsync(user, model.Roles.Where(e => e.IsSelected)
                               .Select(e => e.RoleName));

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
                return NotFound();


            var viewModel = new ProfileModelVM
            {
                Id = Id,
                FullName = user.UserName,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                Phone =user.PhoneNumber,
                Image = user.ImageProfle
            };

            return View(viewModel);
        }

        //public async Task<IActionResult> Edit(string Id)
        //{
        //    var user = await _userManager.FindByIdAsync(Id);

        //    if (user == null)
        //        return NotFound();


        //    var viewModel = new ProfileModelVM
        //    {
        //        Id = Id,
        //        FullName = user.UserName,
        //        Email = user.Email,
        //        UserName = user.UserName
        //    };

        //    return View(viewModel);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileModelVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null) return NotFound();

            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userWithSameEmail != null && userWithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("Email", _localizer["EmailExists"].ToString());
                return View(model);
            }

            var userWithSameuserName = await _userManager.FindByNameAsync(model.UserName);

            if (userWithSameuserName != null && userWithSameuserName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", _localizer["userNameExists"].ToString());
                return View(model);
            }

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);



            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
