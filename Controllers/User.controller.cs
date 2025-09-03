using Microsoft.AspNetCore.Mvc;

namespace loginclaro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase


    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "User controller is working" });
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] modelos.User user)
        {
            if (user.Usuario == "Juli" && user.Password == "123")
            {
                return Ok(new { message = "Login successful" });
            }
            return Unauthorized(new { message = "Invalid credentials" });
        }
    }
}
