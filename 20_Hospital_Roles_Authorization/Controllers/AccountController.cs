using _20_Hospital_Roles_Authorization.Models;
using _20_Hospital_Roles_Authorization.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace _20_Hospital_Roles_Authorization.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IAccountService accountService,UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
           var user = await _accountService.LoginAsync(model);

            if(user != null)
            {
                TempData["Success"] = "Login Successful";
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "Admin");

                if (roles.Contains("Doctor"))
                    return RedirectToAction("Index", "Doctor");

                if (roles.Contains("Nurse"))
                    return RedirectToAction("Index", "Nurse");

                if (roles.Contains("Receptionist"))
                    return RedirectToAction("Index", "Reception");
            }
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);
            if(await _accountService.EmailExistsAsync(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Email already exists.");
                return View(model);
            }

            bool result = await _accountService.RegisterAsync(model);

            if(result)
            {
                TempData["Success"] = "User Registered successful.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registration failed.");
            return View(model);
        }
    }
}
