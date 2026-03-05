// IEmployeeService.cs (Gawin mo ring ganito ang IEmployeeRepository.cs)
using Domain.Models;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee emp);
        void Update(Employee emp);
        void Delete(int id);
    }
}