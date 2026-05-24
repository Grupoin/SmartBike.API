using SmartBike_Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
namespace SmartBike_Mobile.ViewModels
{
   
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUsuarioService _usuarioService = new UsuarioService();

        private string _correo;
        private string _contrasena;
        private string _mensajeError;
        public ICommand IniciandoSesionCommand { get; }
        public ICommand IrARegistroCommand { get; }

        public LoginViewModel()
        {
            IniciandoSesionCommand = new Command(async () => await ValidarAccesoAsync());
            IrARegistroCommand = new Command(async () => await Shell.Current.GoToAsync("RegistroPage"));
        }

        public string Correo
        {
            get => _correo;
            set { _correo = value; OnPropertyChanged(); }
        }

        public string Contrasena
        {
            get => _contrasena;
            set { _contrasena = value; OnPropertyChanged(); }
        }

        public string MensajeError
        {
            get => _mensajeError;
            set { _mensajeError = value; OnPropertyChanged(); }
        }

        private async Task ValidarAccesoAsync()
        {
            // 1. Validación básica
            if (string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(Contrasena))
            {
                MensajeError = "Por favor, ingrese todos los datos.";
                return;
            }

            MensajeError = "Conectando...";

            try
            {
                // 2. Intento de login
                var usuario = await _usuarioService.LoginAsync(
                    Correo.Trim().ToLower(),
                    Contrasena.Trim()
                );
                if (usuario != null)
                {
                    MensajeError = string.Empty;
                    // Navegación exitosa
                    await Shell.Current.GoToAsync("DashboardPage");
                }
                else
                {
                    MensajeError = string.Empty;
                    await Shell.Current.DisplayAlert("Acceso Denegado", "Credenciales incorrectas o usuario no encontrado.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR REAL", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
