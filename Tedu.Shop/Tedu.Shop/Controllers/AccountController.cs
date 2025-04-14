using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tedu.Shop.Data.Entities.System;

namespace Tedu.Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
    , ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        // GET: AccountController
        public async Task<ActionResult> Login()
        {
            var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View();
        }

    }
}
