using Domain.Models;
using System.Collections.Generic;

namespace Framework.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee emp);
        void Update(Employee emp); // Siguraduhing nandito ito
        void Delete(int id);      // Siguraduhing nandito ito
    }
}