using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image_upload.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Image_upload.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /*
         * part 101 Async AND await in c#: tut c# for beginners
         * async func need to be awaited
         * method also need to be async with and rapped with Task
         ***************also check out types like icollection list and iEnumerable
         */
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //2n param is session cookie = lost after we close the browser window
                    //or permannet cookie = permanetly on user machine
                   await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    //what is the model state object why we add here??
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //model recivied is correct type etc...?
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);

                //if sign is succesful redirect to home/idex
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                
            }
            //display the error message from model or loginstate??
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}