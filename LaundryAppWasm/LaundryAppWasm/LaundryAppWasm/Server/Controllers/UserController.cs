using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IServiceProvider _serviceProvider;
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IServiceProvider serviceProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serviceProvider = serviceProvider;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, model.Role);
                    // User successfully registered.
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Registration failed; return validation errors.
            return BadRequest(ModelState);
        }
        [AllowAnonymous]
        [HttpPost("registerrole")]
        public async Task<IActionResult> RegisterRole(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.Name, NormalizedName = model.Name.ToUpper() };
                var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                IdentityResult roleResult;

                var roleCheck = await RoleManager.RoleExistsAsync("Administrator");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole("Administrator"));
                    return Ok();
                }
                else
                {
                    return BadRequest("Role Exists already");
                }
            }

            // Registration failed; return validation errors.
            return BadRequest(ModelState);
        }

        public class RegisterModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(6)]
            public string Password { get; set; }

            [Required]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Role { get; set; }
        }

    }
}
