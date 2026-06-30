using _20_Hospital_Roles_Authorization.Models;

namespace _20_Hospital_Roles_Authorization.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<ApplicationUser?> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<bool> EmailExistsAsync(string email);
    }
}
