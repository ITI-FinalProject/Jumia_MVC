using FinalProject.MVC.Data.statics;
using FinalProject.MVC.Data.ViewModel;
using Jumia_MVC.Data.ViewModel;
using Jumia_MVC.Models;
using Jumia_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;

namespace Jumia_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IHtmlLocalizer<AccountController> _localizer;

        public AccountController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IHtmlLocalizer<AccountController> localizer
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Emaill);

            if (user != null)
            {
                TempData["Error"] = _localizer["inUse"];
                return View(registerVM);

            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.Emaill,
                UserName = registerVM.Emaill,
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (newUserResponse.Succeeded)

                await _userManager.AddToRoleAsync(newUser, UserRole.User);

            var result = await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);
            HttpContext.Session.SetString("USERID", $"{newUser.Id}");

            //if (result.Succeeded)
            //{
            //    // HttpContext.Session.GetString("USERID");


            //    return RedirectToAction("Index", "Home");
            //}
            //return View("RegisterCompleted");
            return RedirectToAction("Index", "Home");




        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByEmailAsync(loginVM.Emaill);
            HttpContext.Session.SetString("USERID", $"{user.Id}");

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                      // HttpContext.Session.GetString("USERID");


                        return RedirectToAction("Index", "Home");
                    }
                }


                TempData["Error"] = _localizer["wrong"];
                return View(loginVM);

            }
            TempData["Error"] = _localizer["wrongPass"];
            return View(loginVM);


        }

        //public async Task<ActionResult> UserProfile(string Id)
        //{
        //    var user = await _userManager.FindByIdAsync(Id);

        //    if (user == null)
        //        return NotFound();


        //    var viewModel = new ProfileModelVM
        //    {
        //        Id = Id,
        //        FullName = user.UserName,
        //        Email = user.Email,
        //        UserName = user.UserName,
        //        Address = user.Address,
        //        Phone = user.PhoneNumber
        //    };

        //    return View();
        //}

        public async Task<ActionResult> UserProfile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
           
            if (user == null)
               return NotFound();


            var viewModel = new ProfileModelVM
            {
               
                FullName = user.UserName,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                Phone = user.PhoneNumber,
                Image=user.ImageProfle
            };
           
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserProfile(ProfileModelVM model)
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
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                //check file size and extencion
                using (var datastrem = new MemoryStream())
                {
                    await file.CopyToAsync(datastrem);
                    user.ImageProfle = datastrem.ToArray();
                }
                await _userManager.UpdateAsync(user);

            }

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;

            await _userManager.UpdateAsync(user);



            return View("updatecompleted");
        }

    }
}

