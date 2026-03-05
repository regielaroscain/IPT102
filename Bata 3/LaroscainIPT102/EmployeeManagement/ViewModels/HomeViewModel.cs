using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Domain.Models;
using Framework.Services;
using EmployeeManagement.Commands;

namespace EmployeeManagement.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IEmployeeService _service;
        private readonly MainViewModel _mainVM;
        public ObservableCollection<Employee> Records { get; set; }

        public ICommand OpenAddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public HomeViewModel(IEmployeeService service, MainViewModel mainVM)
        {
            _service = service; _mainVM = mainVM;
            Records = new ObservableCollection<Employee>(_service.GetAll());

            OpenAddCommand = new RelayCommand(_ => {
                _mainVM.CurrentView = new AddEmployeeViewModel(_service, _mainVM);
            });

            EditCommand = new RelayCommand(o => {
                if (o is Employee emp)
                {
                    _mainVM.CurrentView = new AddEmployeeViewModel(_service, _mainVM, emp);
                }
            });

            DeleteCommand = new RelayCommand(o => {
                if (o is Employee emp)
                {
                    if (MessageBox.Show($"Delete {emp.FirstName}?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _service.Delete(emp.Id); // Wala nang conversion error dito
                        Records.Remove(emp);
                    }
                }
            });
        }
    }
}