using FWshop.Areas.ContectUS.Controllers;
using FWshop.Areas.ContectUS.Models;
using FWshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FWshop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        ConMailController conMail;
        ConMail con;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
            
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() 
                {
                    UserName=model.Name,
                    Email=model.Email,
                
                };
               var result= await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("SignIn");
                }
                else 
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }

            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInVM model)
        {
            if (ModelState.IsValid){

              var user = await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.Rememberme, false);
                if (user.Succeeded)
                {
                    return RedirectToAction("Index" ,"Home");
                }
                else { 
                        ModelState.AddModelError("","Invalid Email or Password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("SignIn");
        }
        
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);
                    con.Title = "";
                    con.Message = passwordResetLink;

                    conMail.SendMail(con);

                    //logger.Log(LogLevel.Warning, passwordResetLink);

                    return RedirectToAction("ConfirmForgetPassword");
                }

                return RedirectToAction("ConfirmForgetPassword");

            }

            return View(model);
        }
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string Email ,string Token)
        {

            if (Email==null || Token==null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }

            return View(model);
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
    }
}
