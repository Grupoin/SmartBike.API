using Microsoft.EntityFrameworkCore;
using SmartBike.Entidades.DTos;
using SmartBike.Entidades;

namespace SmartBike.API.Servicios
{
    public class RegistroDiarioServicio : IRegistroDiarioServicio
    {
        private readonly SmartBikeAPIContext _context;

        public RegistroDiarioServicio(SmartBikeAPIContext context)
        {
            _context = context;
        }

        public async Task<RegistroDiarioResponseDto> RegistrarActividadAsync(RegistroDiarioCreateDto dto)
        {
            // 1. Crear el registro del viaje diario
            var nuevoRegistro = new RegistroDiario
            {
                Fecha = DateTime.Now,
                Co2Generado = dto.Co2Generado,
                IdUsuario = dto.IdUsuario,
                IdTipoTransporte = dto.IdTipoTransporte,
                IdCamara = dto.IdCamara
            };

            _context.RegistroDiarios.Add(nuevoRegistro);

            // 2. Lógica Automática: Actualizar el acumulado en el Historial del usuario
            var historialExistente = await _context.Historiales
                .FirstOrDefaultAsync(h => h.IdUsuario == dto.IdUsuario && h.IdTipoTransporte == dto.IdTipoTransporte);

            if (historialExistente != null)
            {
                // Si ya existe registro para ese usuario y transporte, sumamos el nuevo CO2
                historialExistente.Co2Acumulado += dto.Co2Generado;
                historialExistente.Fecha = DateTime.Now;
            }
            else
            {
                // Si es la primera vez que usa este tipo de transporte, creamos su fila de historial
                var nuevoHistorial = new Historial
                {
                    Fecha = DateTime.Now,
                    Co2Acumulado = dto.Co2Generado,
                    IdUsuario = dto.IdUsuario,
                    IdTipoTransporte = dto.IdTipoTransporte
                };
                _context.Historiales.Add(nuevoHistorial);
            }

            // Guardamos todos los cambios en bloque dentro de una sola transacción de SQL Server
            await _context.SaveChangesAsync();

            // 3. Retornar la respuesta con los nombres listos para el JSON de la App móvil
            var res = await _context.RegistroDiarios
                .Include(r => r.Usuario)
                .Include(r => r.TipoTransporte)
                .Include(r => r.Camara)
                .FirstOrDefaultAsync(r => r.IdReg == nuevoRegistro.IdReg);

            return new RegistroDiarioResponseDto
            {
                IdReg = res!.IdReg,
                Fecha = res.Fecha,
                Co2Generado = res.Co2Generado,
                UsuarioNombre = $"{res.Usuario.Nombres} {res.Usuario.Apellidos}",
                TransporteDetalle = res.TipoTransporte.Detalles,
                CamaraCodigo = res.Camara.IdCamara
            };
        }

        public async Task<IEnumerable<RegistroDiarioResponseDto>> ObtenerPorUsuarioAsync(string cedula)
        {
            return await _context.RegistroDiarios
                .Include(r => r.Usuario)
                .Include(r => r.TipoTransporte)
                .Include(r => r.Camara)
                .Where(r => r.IdUsuario == cedula)
                .OrderByDescending(r => r.Fecha)
                .Select(r => new RegistroDiarioResponseDto
                {
                    IdReg = r.IdReg,
                    Fecha = r.Fecha,
                    Co2Generado = r.Co2Generado,
                    UsuarioNombre = $"{r.Usuario.Nombres} {r.Usuario.Apellidos}",
                    TransporteDetalle = r.TipoTransporte.Detalles,
                    CamaraCodigo = r.Camara.IdCamara
                })
                .ToListAsync();
        }
    }
}
