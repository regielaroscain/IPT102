using IPT102LaroscainDomain.Models;

namespace IPT102LaroscainRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}