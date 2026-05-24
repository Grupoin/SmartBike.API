using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBike_Mobile.Models;

namespace SmartBike_Mobile.Services
{
    public interface ICatalogoService
    {
        Task<List<TipoUsuarioResponse>> ObtenerTiposUsuarioAsync();
        Task<List<TipoTransporteResponse>> ObtenerTiposTransporteAsync();
    }   
}
