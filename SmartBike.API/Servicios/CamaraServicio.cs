using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;
using SmartBike.Entidades;

namespace SmartBike.API.Servicios
{
    public class CamaraServicio : ICamaraServicio
    {
        private readonly SmartBikeAPIContext _context;

        public CamaraServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<CamaraResponseDto> RegistrarAsync(CamaraCreateDto dto)
        {
            var nuevaCamara = new Camara
            {
                IdCamara = dto.IdCamara,
                IdTipoTransporte = dto.IdTipoTransporte,
                IdUsuario = dto.IdUsuario,
                IpCamara = dto.IpCamara,
                FechaHora = DateTime.Now
            };

            _context.Camaras.Add(nuevaCamara);
            await _context.SaveChangesAsync();

            // Retornamos el DTO con los Includes para que la App Móvil vea nombres y detalles
            var resultado = await _context.Camaras
                .Include(c => c.TipoTransporte)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.IdCam == nuevaCamara.IdCam);

            return new CamaraResponseDto
            {
                IdCam = resultado!.IdCam,
                IdCamara = resultado.IdCamara,
                IpCamara = resultado.IpCamara,
                FechaHoraAsignacion = resultado.FechaHora,
                TipoTransporteDetalle = resultado.TipoTransporte?.Detalles ?? "N/A",
                OperadorNombre = resultado.Usuario != null ? $"{resultado.Usuario.Nombres} {resultado.Usuario.Apellidos}" : "Sin asignar"
            };
        }

        public async Task<IEnumerable<CamaraResponseDto>> ObtenerTodasAsync()
        {
            return await _context.Camaras
                .Include(c => c.TipoTransporte)
                .Include(c => c.Usuario)
                .Select(c => new CamaraResponseDto
                {
                    IdCam = c.IdCam,
                    IdCamara = c.IdCamara,
                    IpCamara = c.IpCamara,
                    FechaHoraAsignacion = c.FechaHora,
                    TipoTransporteDetalle = c.TipoTransporte.Detalles,
                    OperadorNombre = $"{c.Usuario.Nombres} {c.Usuario.Apellidos}"
                })
                .ToListAsync();
        }
    }
}