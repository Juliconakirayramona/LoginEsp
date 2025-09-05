using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace loginclaro.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	internal class UserController : ControllerBase
	{
		/// <summary>
		/// Esto es para comprobar que el controlador está funcionando, y el login también
		/// </summary>
		/// <returns> nos retorna un mensaje de que si entramos</returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(new { message = "User controller is working" });
		}

		[HttpPost("Login")]
		public IActionResult Login([FromBody] modelos.User user)
		{
			if (user.Usuario == "Juli" && user.Password == "123")
			{
				return Ok(new { message = "Login successful" });
			}//Cierre del if
			return Unauthorized(new { message = "Invalid credentials" });
		}
	}
}
