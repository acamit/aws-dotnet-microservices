using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Advertising.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [StringLength(20, ErrorMessage = "Password must be atleast 8 characeters long", MinimumLength = 8)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
