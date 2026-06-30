using _20_Hospital_Roles_Authorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace _20_Hospital_Roles_Authorization.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            var user= await _userManager.FindByEmailAsync(email);
            return user!= null;
        }

        public async Task<ApplicationUser?> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                model.Password,
                false, false);

            if(!result.Succeeded)
                return null;
            return user;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            return result.Succeeded;
        }
    }
}
