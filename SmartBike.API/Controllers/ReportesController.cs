using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBike.API.Servicios;

namespace SmartBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteServicio _reporteServicio;

        public ReportesController(IReporteServicio reporteServicio)
        {
            _reporteServicio = reporteServicio;
        }

        // POST: api/reportes/generar?idTipoTransporte=1&periodo=Mayo 2026
        [HttpPost("generar")]
        public async Task<IActionResult> GenerarReporte([FromQuery] int idTipoTransporte, [FromQuery] string periodo)
        {
            var reporte = await _reporteServicio.GenerarReporteMensualAsync(idTipoTransporte, periodo);
            return Ok(reporte);
        }

        // GET: api/reportes/historico
        [HttpGet("historico")]
        public async Task<IActionResult> ObtenerHistorico()
        {
            var lista = await _reporteServicio.ObtenerHistoricoReportesAsync();
            return Ok(lista);
        }
    }
}
