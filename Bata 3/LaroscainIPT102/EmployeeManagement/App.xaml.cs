using System.Windows;
using EmployeeManagement.Views; // Siguraduhing nandito ito
using EmployeeManagement.ViewModels;
using Framework.Repositories;
using Framework.Services;

namespace EmployeeManagement
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Setup Data
            var repo = new EmployeeRepository();
            var service = new EmployeeService(repo);

            // 2. Setup ViewModel
            var mainVM = new MainViewModel(service);

            // 3. Setup Window (Dito natin tinuturo sa Views folder)
            var window = new MainWindow();
            window.DataContext = mainVM;

            // 4. Ipakita ang window
            window.Show();
        }
    }
}