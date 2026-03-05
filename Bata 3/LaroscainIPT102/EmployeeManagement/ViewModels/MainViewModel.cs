using Framework.Services;

namespace EmployeeManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel(IEmployeeService service)
        {
            // Default view pagbukas ng app
            CurrentView = new HomeViewModel(service, this);
        }
    }
}