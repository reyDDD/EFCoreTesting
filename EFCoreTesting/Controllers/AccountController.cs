using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EFCoreTesting.Models.Account;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EFCoreTesting.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private ILogger<AccountController> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<MyIdentityUser> userManager, ILogger<AccountController> logger, SignInManager<MyIdentityUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register2(LoginModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new MyIdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                        $"Пожалуйста, подтвердите e-mail - <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>кликните здесь</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation",
                                              new { email = model.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login2(LoginModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, 
                // set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email,
                                   model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new
                    {
                        ReturnUrl = returnUrl,
                        RememberMe = model.RememberMe
                    });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Login");
                }
            }

            return View("Login");
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                if (returnUrl.Contains("Home"))
                {
                    return LocalRedirect("/Home/Index2");
                }
                return LocalRedirect(returnUrl);
            }
            else
            {
                return LocalRedirect("/Home/Index2");
            }
        }
    }
}
