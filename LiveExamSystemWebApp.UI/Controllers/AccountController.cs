using LiveExamSystemWebApp.Business.Abstract;
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

        [Route("/account/logout/")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
}
