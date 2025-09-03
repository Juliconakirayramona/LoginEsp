using Microsoft.AspNetCore.Mvc;
using loginclaro.Servicio;

namespace loginclaro.Controllers
{
    [ApiController]
    [Route("api/estudiante")]
    public class ControllerEstudiante : ControllerBase

    {
        private readonly string _connectionString = "User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES";
        private readonly Servicio.EstudianteServicio? _servicioEstudiante;

        public ControllerEstudiante(Servicio.EstudianteServicio servicioEstudiante)
        {
            _servicioEstudiante = servicioEstudiante;
        }

        [HttpPost("agregar")]
        public IActionResult AgregarEstudiante([FromBody] modelos.Estudiantes estudiante)
        {
            try
            {
                _servicioEstudiante?.AgregarEstudiante(estudiante);
                return Ok("Estudiante agregado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al agregar estudiante: " + ex.Message);
            }

        }
        [HttpGet("obtener")]
        public IActionResult ObtenerEstudiantes()
        {
            try
            {
                var estudiantes = _servicioEstudiante?.ObtenerEstudiantes();
                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al obtener estudiantes: " + ex.Message);
            }
        }
    }
}
