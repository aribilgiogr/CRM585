using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Web.Models.Account;

namespace UI.Web.Controllers
{
    public class AccountController(IAuthService auth, IMapper mapper) : Controller
    {
        [Authorize(Roles = "SP")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "ADM")]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                var dto = mapper.Map<LoginDto>(model);
                var reply = await auth.LoginAsync(dto);
                if (reply.IsSuccess)
                {
                    return Redirect(returnUrl ?? "~/");
                }
                foreach (var err in reply.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        public IActionResult Register() => View();


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = mapper.Map<RegisterDto>(model);
                var reply = await auth.RegisterAsync(dto);
                if (reply.IsSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var err in reply.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            var reply = await auth.LogoutAsync();
            if (!reply.IsSuccess)
            {
                TempData["Notifications"] = reply.Errors;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult ForgotPassword() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reply = await auth.ForgotPasswordAsync(model.Email);
                if (reply.IsSuccess)
                {
                    TempData["Notifications"] = "Eposta adresinizi kontrol ediniz.";
                    return RedirectToAction("login");
                }
                foreach (var err in reply.Errors!)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
            return View(model);
        }
    }
}
