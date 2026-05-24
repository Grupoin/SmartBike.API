namespace SmartBike_Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegistroPage", typeof(Views.RegistroPage));
            Routing.RegisterRoute("DashboardPage", typeof(Views.DashboardPage));
        }
    }
}
