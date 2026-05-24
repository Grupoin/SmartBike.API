using SmartBike_Mobile.Models;
using SmartBike_Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartBike_Mobile.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        private readonly IUsuarioService _usuarioService = new UsuarioService();
        private readonly CatalogoService _catalogoService = new CatalogoService();

        // Propiedades de datos del formulario
        private string _cedula;
        public string Cedula { get => _cedula; set { _cedula = value; OnPropertyChanged(); } }

        private string _nombres;
        public string Nombres { get => _nombres; set { _nombres = value; OnPropertyChanged(); } }

        private string _apellidos;
        public string Apellidos { get => _apellidos; set { _apellidos = value; OnPropertyChanged(); } }

        private string _correo;
        public string Correo { get => _correo; set { _correo = value; OnPropertyChanged(); } }

        private string _contrasena;
        public string Contrasena { get => _contrasena; set { _contrasena = value; OnPropertyChanged(); } }

        // Propiedades para el Picker de Tipo de Usuario
        public ObservableCollection<TipoUsuarioResponse> TiposUsuario { get; set; } = new();

        private TipoUsuarioResponse _tipoUsuarioSeleccionado;
        public TipoUsuarioResponse TipoUsuarioSeleccionado
        {
            get => _tipoUsuarioSeleccionado;
            set { _tipoUsuarioSeleccionado = value; OnPropertyChanged(); }
        }

        // Comandos
        public ICommand RegistrarUsuarioCommand { get; }
        public ICommand VolverLoginCommand { get; }

        public RegistroViewModel()
        {
            RegistrarUsuarioCommand = new Command(async () => await Registrar());
            VolverLoginCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

            // Cargar datos al iniciar
            CargarTipos();
        }

        private async void CargarTipos()
        {
            var lista = await _catalogoService.ObtenerTiposUsuarioAsync();
            TiposUsuario.Clear();
            foreach (var item in lista)
            {
                TiposUsuario.Add(item);
            }
        }

        private async Task Registrar()
        {
            if (string.IsNullOrEmpty(Cedula) || TipoUsuarioSeleccionado == null)
            {
                await Shell.Current.DisplayAlert("Error", "Por favor completa todos los campos y selecciona un tipo de usuario.", "OK");
                return;
            }

            var nuevoUsuario = new UsuarioCreate
            {
                Cedula = this.Cedula,
                Nombres = this.Nombres,
                Apellidos = this.Apellidos,
                CorreoInstitucional = this.Correo,
                Contrasena = this.Contrasena,
                IdTipoUsuario = TipoUsuarioSeleccionado.IdTip // Usamos IdTip como definimos en el Modelo
            };

            var resultado = await _usuarioService.RegistrarUsuarioAsync(nuevoUsuario);

            if (resultado != null)
            {
                await Shell.Current.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo registrar, verifica tu conexión.", "OK");
            }
        }

        // Implementación de INotifyPropertyChanged para actualizar la vista
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string n = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
