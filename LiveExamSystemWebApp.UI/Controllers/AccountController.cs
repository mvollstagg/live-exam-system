using System.Security.Claims;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Core.Utilities.Security.Hashing;
using LiveExamSystemWebApp.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LiveExamSystemWebApp.UI.Controllers;

public class AccountController : Controller
{
    private readonly IAppUserService _appUserService;
        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [Route("/account/login/")]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("/account/login/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AppUser appUser, string returnUrl = null)
        {
            var user = await _appUserService.SignInAsync(appUser);
            if (!user.Success)
            {
                TempData["Error"] = user.Message;
                return View(appUser);
            }
            TempData["Success"] = user.Message;
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("/account/register/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AppUser appUser)
        {
            appUser.Role = "User";
            appUser.IsActived = true;
            appUser.Token = "Token";
            appUser.PasswordHash = HashingHelper.CreatePasswordHashOld(appUser.Password, appUser.SecretKey);
            var user = await _appUserService.AddAsync(appUser);
            if (!user.Success)
            {
                TempData["Error"] = user.Message;
                return View(appUser);
            }
            TempData["Success"] = user.Message;
            
            return RedirectToAction("Index", "Account");
        }

        [Route("/account/profile/")]
        public async Task<IActionResult> Profile()
        {
            var user = await _appUserService.GetByUserEmailAsync(HttpContext.User.FindFirst(ClaimTypes.Email).Value);
            return View(user.Data);
        }

        [Route("/account/profile/")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(AppUser appUser)
        {
            appUser.PasswordHash = HashingHelper.CreatePasswordHashOld(appUser.Password, appUser.SecretKey);
            var user = await _appUserService.UpdateAsync(appUser);
            if (!user.Success)
            {
                TempData["Error"] = user.Message;
                return View(appUser);
            }
            TempData["Success"] = user.Message;
            
            return RedirectToAction("Profile", "Account");
        }

        [Route("/account/logout/")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
}
