using loginclaro.modelos;
using Microsoft.AspNetCore.Mvc;

namespace loginclaro.Controllers
{
    [ApiController]
    [Route("api/materia")]
    public class ControllerMateria : ControllerBase

    {
        private readonly Servicio.MateriaServicio? _servicioMateria;
        public ControllerMateria(Servicio.MateriaServicio servicioMateria)
        {
            _servicioMateria = servicioMateria;
        }
        [HttpPost("agregarM")]
        public IActionResult AgregarMateria([FromBody] modelos.Materias materia)
        {
            try
            {
                _servicioMateria?.AgregarMateria(materia);
                return Ok("Materia agregada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al agregar materia: " + ex.Message);
            }
        }
        [HttpGet("obtenerM")]

        public IActionResult ObtenerMaterias()
        {
            var materias = _servicioMateria?.ObtenerMaterias();
            return Ok(materias);
        }
        [HttpPost("promedio/{EstudianteId}")]
        public IActionResult CalcularNota(int EstudianteId)
        {
            try
            {
                var promedio = _servicioMateria?.Promedio(EstudianteId);
                return Ok(promedio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al calcular el promedio: " + ex.Message);
            }
        }
    }
}
    