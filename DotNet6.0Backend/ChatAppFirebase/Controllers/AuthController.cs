using Microsoft.AspNetCore.Mvc;
using Services.fbInterface;
using Services.fbServices;
using Services.RequestDto;

namespace ChatAppFirebase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IfbAuthService _authService;

        public AuthController(IfbAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto signInRequest)
        {
            if (string.IsNullOrEmpty(signInRequest.Email) || string.IsNullOrEmpty(signInRequest.Password))
            {
                return BadRequest("Email and password are required.");
            }

            try
            {
                string userId = await _authService.SignInWithEmailPasswordAsync(signInRequest.Email, signInRequest.Password);
                return Ok(new { UserId = userId });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = "Invalid email or password.", details = ex.Message });
            }
        }

    }
}
