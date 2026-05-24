using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public class HistorialServicio : IHistorialServicio
    {
        private readonly SmartBikeAPIContext _context;

        public HistorialServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialResponseDto>> ObtenerResumenUsuarioAsync(string cedula)
        {
            return await _context.Historiales
                .Include(h => h.Usuario)
                .Include(h => h.TipoTransporte)
                .Where(h => h.IdUsuario == cedula)
                .Select(h => new HistorialResponseDto
                {
                    IdHi = h.IdHi,
                    Fecha = h.Fecha,
                    Co2Acumulado = h.Co2Acumulado,
                    UsuarioNombre = $"{h.Usuario.Nombres} {h.Usuario.Apellidos}",
                    TransporteDetalle = h.TipoTransporte.Detalles
                })
                .ToListAsync();
        }
    }
}
