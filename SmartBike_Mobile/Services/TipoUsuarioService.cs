using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SmartBike_Mobile.Models;
namespace SmartBike_Mobile.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly HttpClient _httpClient;
        // Cambia la línea BaseUrl así:
        private const string BaseUrl = "http://192.168.0.103:5023/api/tipousuarios";

        public TipoUsuarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<TipoUsuarioResponse>> ObtenerTodosAsync()    
        {
            try
            {
                var respuesta = await _httpClient.GetAsync(BaseUrl);
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<List<TipoUsuarioResponse>>() ?? new List<TipoUsuarioResponse>();
                }
                return new List<TipoUsuarioResponse>();
            }
            catch (Exception)
            {
                return new List<TipoUsuarioResponse>();
            }
        }
    }
}
