using FakeForum.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace FakeForum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Me")]
        public IActionResult GetCurrentUser()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var username = User.Identity.Name;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return Ok(new
                {
                    isAuthenticated = true,
                    id = userId,
                    username = username
                });

            }
            return Ok(new { isAuthenticated = false });
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> LoadProfile(string username)
        {
            var user = await _userRepository.GetByUsername(username);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(new
            {
                id = user.Id,
                username = user.Username,
                avatar = user.AvatarUrl,
                bio = user.Bio
            });
        }
    }
}
