namespace Framework.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Framework.Repositories.IEmployeeRepository _repo;
        public EmployeeService(Framework.Repositories.IEmployeeRepository repo) { _repo = repo; }

        public System.Collections.Generic.IEnumerable<Domain.Models.Employee> GetAll() => _repo.GetAll();
        public void Add(Domain.Models.Employee emp) => _repo.Add(emp);
        public void Update(Domain.Models.Employee emp) => _repo.Update(emp);
        public void Delete(int id) => _repo.Delete(id);
    }
}