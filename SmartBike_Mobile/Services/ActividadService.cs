using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SmartBike_Mobile.Models;

namespace SmartBike_Mobile.Services
{
    public class ActividadService : IActividadService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://192.168.0.103:5023/api/actividades/";
        public ActividadService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<RegistroDiarioResponse?> RegistrarViajeAsync(RegistroDiarioCreate viaje)
        {
            try
            {
                var respuesta = await _httpClient.PostAsJsonAsync($"{BaseUrl}registrar-viaje", viaje);
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<RegistroDiarioResponse>();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<RegistroDiarioResponse>> ObtenerHistorialUsuarioAsync(string cedula)
        {
            try
            {
                var respuesta = await _httpClient.GetAsync($"{BaseUrl}historial-usuario/{cedula}");
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<List<RegistroDiarioResponse>>() ?? new List<RegistroDiarioResponse>();
                }
                return new List<RegistroDiarioResponse>();
            }
            catch (Exception)
            {
                return new List<RegistroDiarioResponse>();
            }
        }

        public async Task<List<HistorialResponse>> ObtenerResumenTotalesAsync(string cedula)
        {
            try
            {
                var respuesta = await _httpClient.GetAsync($"{BaseUrl}resumen-totales/{cedula}");
                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<List<HistorialResponse>>() ?? new List<HistorialResponse>();
                }
                return new List<HistorialResponse>();
            }
            catch (Exception)
            {
                return new List<HistorialResponse>();
            }
        }
    }
}
