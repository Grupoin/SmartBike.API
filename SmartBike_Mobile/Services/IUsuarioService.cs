using SmartBike_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike_Mobile.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse?> RegistrarUsuarioAsync(UsuarioCreate usuario);
        Task<UsuarioResponse?> LoginAsync(string correo, string contrasena);
    }
}
