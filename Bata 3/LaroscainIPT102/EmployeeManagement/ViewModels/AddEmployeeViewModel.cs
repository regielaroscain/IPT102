using System.Windows.Input;
using Domain.Models;
using Framework.Services;
using EmployeeManagement.Commands;

namespace EmployeeManagement.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        private readonly IEmployeeService _service;
        private readonly MainViewModel _mainVM;
        private readonly Employee _selectedEmp;

        private string _fName; public string FirstName { get => _fName; set { _fName = value; OnPropertyChanged(); } }
        private string _lName; public string LastName { get => _lName; set { _lName = value; OnPropertyChanged(); } }
        private string _pos; public string Position { get => _pos; set { _pos = value; OnPropertyChanged(); } }
        private string _dept; public string Department { get => _dept; set { _dept = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEmployeeViewModel(IEmployeeService service, MainViewModel mainVM, Employee selectedEmp = null)
        {
            _service = service; _mainVM = mainVM; _selectedEmp = selectedEmp;

            if (_selectedEmp != null)
            {
                FirstName = _selectedEmp.FirstName; LastName = _selectedEmp.LastName;
                Position = _selectedEmp.Position; Department = _selectedEmp.Department;
            }

            SaveCommand = new RelayCommand(_ => {
                var emp = new Employee
                {
                    Id = _selectedEmp?.Id ?? 0,
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Position = this.Position,
                    Department = this.Department
                };

                if (_selectedEmp == null) _service.Add(emp);
                else _service.Update(emp);

                _mainVM.CurrentView = new HomeViewModel(_service, _mainVM);
            });

            CancelCommand = new RelayCommand(_ => {
                _mainVM.CurrentView = new HomeViewModel(_service, _mainVM);
            });
        }
    }
}