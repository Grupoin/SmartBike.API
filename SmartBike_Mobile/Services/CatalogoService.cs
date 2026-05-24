using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SmartBike_Mobile.Models;
namespace SmartBike_Mobile.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://192.168.0.103:5023/api/";
        public CatalogoService()
        {
            _httpClient = new HttpClient();
        }

        // Asegúrate de que esta ruta sea la correcta en tu API
        public async Task<List<TipoUsuarioResponse>> ObtenerTiposUsuarioAsync()
        {
            try
            {
                // La URL debe ser: http://192.168.0.103:5023/api/tipousuarios
                var respuesta = await _httpClient.GetAsync($"{BaseUrl}tipousuarios");
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<List<TipoUsuarioResponse>>();
                }
                return new List<TipoUsuarioResponse>();
            }
            catch (Exception ex)
            {
                // Esto te dirá en la consola de salida si hay error de conexión o de lectura JSON
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return new List<TipoUsuarioResponse>();
            }
        }
        public async Task<List<TipoTransporteResponse>> ObtenerTiposTransporteAsync()
        {
            try
            {
                var respuesta = await _httpClient.GetAsync($"{BaseUrl}transportes");
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<List<TipoTransporteResponse>>() ?? new List<TipoTransporteResponse>();
                }
                return new List<TipoTransporteResponse>();
            }
            catch (Exception)
            {
                return new List<TipoTransporteResponse>();
            }
        }
    }
}
