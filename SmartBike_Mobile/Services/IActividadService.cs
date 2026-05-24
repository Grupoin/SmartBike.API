using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBike_Mobile.Models;

namespace SmartBike_Mobile.Services
{
    public interface IActividadService
    {
        Task<RegistroDiarioResponse?> RegistrarViajeAsync(RegistroDiarioCreate viaje);
        Task<List<RegistroDiarioResponse>> ObtenerHistorialUsuarioAsync(string cedula);
        Task<List<HistorialResponse>> ObtenerResumenTotalesAsync(string cedula);
    }
}
