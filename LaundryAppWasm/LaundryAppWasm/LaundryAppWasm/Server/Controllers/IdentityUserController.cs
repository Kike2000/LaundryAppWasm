using LaundryAppWasm.Shared.ModelValidations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class IdentityUserController : Controller
    {
        private readonly IAuthenticationService _IAuthenticationService;
        public IdentityUserController(IAuthenticationService authenticationService)
        {
            _IAuthenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] BaseUserValidationModel baseUser)
        {
            //try
            //{
            //    // Replace the following line with your actual authentication logic
            //    var user = await _IAuthenticationService.AuthenticateAsync(baseUser.UserEmail, baseUser.Password);

            //    if (user == null)
            //    {
            //        return Unauthorized(new { Message = "Invalid credentials" });
            //    }

            //    // Generate JWT token
            //    var token = _IAuthenticationService.GenerateJwtToken(user);

            //    return Ok(new { Token = token });
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { Message = "An error occurred while processing your request", Error = ex.Message });
            //}
            return Ok();
        }
    }
}
