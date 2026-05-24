using SmartBike_Mobile.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartBike_Mobile.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly IActividadService _actividadService;
        private string _saludo = "Hola, bienvenido";
        private decimal _totalCo2;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DashboardViewModel()
        {
            _actividadService = new ActividadService();
            CerrarSesionCommand = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
            _ = CargarDatosIniciales();
        }

        public string Saludo { get => _saludo; set { _saludo = value; OnPropertyChanged(); } }
        public decimal TotalCo2 { get => _totalCo2; set { _totalCo2 = value; OnPropertyChanged(); } }
        public ICommand CerrarSesionCommand { get; }

        private async Task CargarDatosIniciales()
        {
            // Aquí llamarías a tu servicio para obtener los totales reales
            // var datos = await _actividadService.ObtenerTotalesAcumuladosAsync(cedulaGuardada);
            TotalCo2 = 12.5m; // Dato de prueba
        }

        protected void OnPropertyChanged([CallerMemberName] string p = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
