using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBike.API.Servicios;
using SmartBike.Entidades.DTos;

namespace SmartBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly IRegistroDiarioServicio _registroServicio;
        private readonly IHistorialServicio _historialServicio;

        public ActividadesController(IRegistroDiarioServicio registroServicio, IHistorialServicio historialServicio)
        {
            _registroServicio = registroServicio;
            _historialServicio = historialServicio;
        }

        // POST: api/actividades/registrar-viaje
        [HttpPost("registrar-viaje")]
        public async Task<IActionResult> RegistrarViaje([FromBody] RegistroDiarioCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var resultado = await _registroServicio.RegistrarActividadAsync(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET: api/actividades/historial-usuario/100xxxxxxx
        [HttpGet("historial-usuario/{cedula}")]
        public async Task<IActionResult> ObtenerHistorialUsuario(string cedula)
        {
            var historial = await _registroServicio.ObtenerPorUsuarioAsync(cedula);
            return Ok(historial);
        }

        // GET: api/actividades/resumen-totales/100xxxxxxx
        [HttpGet("resumen-totales/{cedula}")]
        public async Task<IActionResult> ObtenerResumenTotales(string cedula)
        {
            var resumen = await _historialServicio.ObtenerResumenUsuarioAsync(cedula);
            return Ok(resumen);
        }
    }
}
