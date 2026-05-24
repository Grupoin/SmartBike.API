using SmartBike.Entidades.DTos;
using SmartBike.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SmartBike.API.Servicios
{
    public class TipoTransporteServicio : ITipoTransporteServicio
    {
        private readonly SmartBikeAPIContext _context;

        public TipoTransporteServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<TipoTransporteResponseDto> CrearAsync(TipoTransporteCreateDto dto)
        {
            var transporte = new TipoTransporte
            {
                Detalles = dto.Detalles,
                EsCeroEmision = dto.EsCeroEmision
            };

            _context.TipoTransportes.Add(transporte);
            await _context.SaveChangesAsync();

            return new TipoTransporteResponseDto
            {
                IdTipTra = transporte.IdTipTra,
                Detalles = transporte.Detalles,
                EsCeroEmision = transporte.EsCeroEmision
            };
        }

        public async Task<IEnumerable<TipoTransporteResponseDto>> ObtenerTodosAsync()
        {
            return await _context.TipoTransportes
                .Select(t => new TipoTransporteResponseDto
                {
                    IdTipTra = t.IdTipTra,
                    Detalles = t.Detalles,
                    EsCeroEmision = t.EsCeroEmision
                })
                .ToListAsync();
        }
    }
}
