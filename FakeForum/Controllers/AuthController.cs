using Microsoft.AspNetCore.Mvc;
using FakeForum.Services;
using FakeForum.DTOs;


namespace FakeForum.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var token = await _auth.CreateUser(
                request.Username,
                request.Email,
                request.Password
            );
            if (token == null)
            {
                return Unauthorized(new { error = "Invalid username or password" });
            }
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var token = await _auth.LogIn(
                    request.Email,
                    request.Password
                );
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
