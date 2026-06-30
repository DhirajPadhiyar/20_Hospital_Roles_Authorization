using System.ComponentModel.DataAnnotations;

namespace _20_Hospital_Roles_Authorization.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Enter valid Email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
