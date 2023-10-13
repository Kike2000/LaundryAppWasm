using static LaundryAppWasm.Server.Controllers.AccountController;
using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class UserInfo
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class RegisterModel : UserInfo
    {

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
