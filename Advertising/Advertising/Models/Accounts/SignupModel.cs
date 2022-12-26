using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Advertising.Models.Accounts
{
    public class SignupModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [StringLength(8, ErrorMessage = "Password must be atleast 8 characeters long")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [Compare("Password", ErrorMessage = "Passwords should match")]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassowrd { get; set; }
    }
}
