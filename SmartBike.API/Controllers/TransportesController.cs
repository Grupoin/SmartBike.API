using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBike.API.Servicios;
using SmartBike.Entidades.DTos;

namespace SmartBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportesController : ControllerBase
    {
        private readonly ITipoTransporteServicio _transporteServicio;

        public TransportesController(ITipoTransporteServicio transporteServicio)
        {
            _transporteServicio = transporteServicio;
        }

        // POST: api/transportes
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TipoTransporteCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var resultado = await _transporteServicio.CrearAsync(dto);
            return Ok(resultado);
        }

        // GET: api/transportes
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _transporteServicio.ObtenerTodosAsync();
            return Ok(lista);
        }
    }
}
