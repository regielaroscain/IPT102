using System.Windows;
using IPT102LaroscainDomain.Models;
using IPT102LaroscainRepository.Interfaces;
using IPT102LaroscainRepository.Services;

namespace IPT102LaroscainWpfApp
{
    public partial class MainWindow : Window
    {
        private readonly IEmployeeRepository _repo;
        // Same string from your Blazor project
        private const string ConnString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IPT102LaroscainData;Integrated Security=True;TrustServerCertificate=True;";

        public MainWindow()
        {
            InitializeComponent();
            // Manual Injection of the repository
            _repo = new EmployeeRepository(ConnString);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgEmployees.ItemsSource = _repo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;

            var emp = new Employee
            {
                Name = txtName.Text,
                Position = txtPosition.Text,
                Salary = decimal.TryParse(txtSalary.Text, out decimal s) ? s : 0
            };

            _repo.Add(emp);
            LoadData();

            // Clear inputs
            txtName.Text = ""; txtPosition.Text = ""; txtSalary.Text = "";
        }

        private void OnRefreshClick(object sender, RoutedEventArgs e) => LoadData();

        private void OnExitClick(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}