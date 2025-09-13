using System.Windows;

namespace SPP.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadInitialView();
        }

        private void LoadInitialView()
        {
            // Load the login view as the initial view
            var loginView = new Views.LoginView();
            MainContentControl.Content = loginView;
        }

        private void OnLoginSuccessful()
        {
            // Navigate to the dashboard view upon successful login
            var dashboardView = new Views.DashboardView();
            MainContentControl.Content = dashboardView;
        }

        private void OnLogout()
        {
            // Navigate back to the login view on logout
            LoadInitialView();
        }
    }
}