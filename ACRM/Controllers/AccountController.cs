using ACRM.src.Domain.Entity;
using ACRM.src.Domain.ViewModel.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ACRM.Controllers
{
    public class AccountController(UserManager<Employer> userMgr, SignInManager<Employer> signinMgr) : Controller
    {
        private readonly UserManager<Employer> _userManager = userMgr;
        private readonly SignInManager<Employer> _signInManager = signinMgr;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn(string returnUrl)
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.returnUrl = returnUrl;
            return View(new LoginVM());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginVM model, string returnUrl)
        {

            Employer user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }}
