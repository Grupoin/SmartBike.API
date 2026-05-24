using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;

namespace SmartBike.API.Servicios
{
    public class TipoUsuarioServicio : ITipoUsuarioServicio
    {
        private readonly SmartBikeAPIContext _context;

        public TipoUsuarioServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoUsuarioResponseDto>> ObtenerTodosAsync()
        {
            return await _context.TipoUsuarios
                .Select(t => new TipoUsuarioResponseDto
                {
                    IdTip = t.IdTip,
                    Detalle = t.Detalle
                })
                .ToListAsync();
        }
    }
}
