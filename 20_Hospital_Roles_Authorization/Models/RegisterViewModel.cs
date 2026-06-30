using System.ComponentModel.DataAnnotations;

namespace _20_Hospital_Roles_Authorization.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        [EmailAddress(ErrorMessage ="Enter valid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare("Password",ErrorMessage ="Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;

    }
}
