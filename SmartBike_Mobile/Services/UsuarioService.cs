using SmartBike_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _httpClient;

        // Reemplaza con el puerto exacto que te dio Swagger en tu backend
        private const string BaseUrl = "http://192.168.0.103:5023/api/usuarios/";

        public UsuarioService()
        {
            // En entornos de desarrollo locales con HTTPS, a veces se requieren configuraciones de SSL bypass.
            // Para pruebas iniciales, asegúrate de que tu API acepte conexiones HTTP normales si te da problemas el certificado.
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
        }

        public async Task<UsuarioResponse?> BuscarUsuarioAsync(string cedula)
        {
            try
            {
                var respuesta = await _httpClient.GetAsync($"{BaseUrl}buscar/{cedula}");

                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<UsuarioResponse>();
                }

                return null;
            }
            catch (Exception)
            {
                // Aquí puedes manejar caídas de red o servidores apagados
                return null;
            }
        }

        public async Task<UsuarioResponse?> RegistrarUsuarioAsync(UsuarioCreate usuario)
        {
            try
            {
                var respuesta = await _httpClient.PostAsJsonAsync($"{BaseUrl}registrar", usuario);

                if (respuesta.IsSuccessStatusCode)
                {
                    return await respuesta.Content.ReadFromJsonAsync<UsuarioResponse>();
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<UsuarioResponse?> LoginAsync(string correo, string contrasena)
        {
            var credenciales = new { CorreoInstitucional = correo, Contrasena = contrasena };
            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://192.168.0.103:5023/api/usuarios/login", credenciales);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UsuarioResponse>();
                }
                else
                {
                    // AQUÍ ESTÁ EL TRUCO:
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"ERROR DE API: {errorContent}"); // Mira esto en la salida de VS
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EXCEPCIÓN: {ex.Message}"); // Mira esto
                throw; // Deja que el error suba para saber qué está pasando
            }
        }

    }
}
