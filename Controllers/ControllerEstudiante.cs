using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace loginclaro.Controllers
{
	/// <summary>
	/// Acá simplemente creamos el controlador de estudiante, y llamamos a los servicios.
	/// </summary>
	[ApiController]
	[Route("api/estudiante")]
	public class ControllerEstudiante : ControllerBase

	{
		private readonly String connectionString = "User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES";
		private readonly Servicio.EstudianteServicio? servicioEstudiante;
		public ControllerEstudiante(Servicio.EstudianteServicio servicioEstudiante)
		{
			this.servicioEstudiante = servicioEstudiante;
		}

		[HttpPost("agregar")]
		public IActionResult AgregarEstudiante([FromBody] modelos.Estudiantes estudiante)
		{
			try
			{
				servicioEstudiante?.AgregarEstudiante(estudiante);
				return Ok("Estudiante agregado exitosamente.");
			}//Cierre del try
			catch (Exception ex)
			{
				return StatusCode(500, "Error al agregar estudiante: " + ex.Message);
			}//Cierre del catch

		}

		[HttpGet("obtener")]
		public IActionResult ObtenerEstudiantes()
		{
			try
			{
				List<modelos.Estudiantes>? estudiantes = servicioEstudiante?.ObtenerEstudiantes();
				return Ok(estudiantes);
			}//Cierre del try
			catch (Exception ex)
			{
				return StatusCode(500, "Error al obtener estudiantes: " + ex.Message);
			}//Cierre del catch
		}
	}
}
