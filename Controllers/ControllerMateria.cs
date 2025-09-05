using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace loginclaro.Controllers
{
	/// <summary>
	/// Acá simplemente creamos el controlador de materia, y llamamos a los servicios
	/// </summary>
	[ApiController]
	[Route("api/materia")]
	public class ControllerMateria : ControllerBase

	{
		private readonly Servicio.MateriaServicio? servicioMateria;
		public ControllerMateria(Servicio.MateriaServicio servicioMateria)
		{
			this.servicioMateria = servicioMateria;
		}

		[HttpPost("AgregarM")]
		public IActionResult AgregarMateria([FromBody] modelos.Materias materia)
		{
			try
			{
				servicioMateria?.AgregarMateria(materia);
				return Ok("Materia agregada exitosamente.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error al agregar materia: " + ex.Message);
			}
		}

		[HttpGet("ObtenerM")]

		public IActionResult ObtenerMaterias()
		{
			List<modelos.Materias>? materias = servicioMateria?.ObtenerMaterias();
			return Ok(materias);
		}

		[HttpPost("Promedio/{EstudianteId}")]
		public IActionResult CalcularNota(Int32 EstudianteId)
		{
			try
			{
				var promedio = servicioMateria?.Promedio(EstudianteId);
				return Ok(promedio);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error al calcular el promedio: " + ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult EliminarMateria(Int32 id)
		{
			try
			{
				servicioMateria?.EliminarMateria(id);
				return Ok("Materia eliminada exitosamente.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error al eliminar materia: " + ex.Message);
			}
		}

	}
}
