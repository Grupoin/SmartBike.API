using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBike.API.Servicios;

namespace SmartBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioServicio _tipoUsuarioServicio;

        public TipoUsuariosController(ITipoUsuarioServicio tipoUsuarioServicio)
        {
            _tipoUsuarioServicio = tipoUsuarioServicio;
        }

        // GET: api/tipousuarios
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _tipoUsuarioServicio.ObtenerTodosAsync();
            return Ok(lista);
        }
    }
}
