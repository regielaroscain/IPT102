using IPT102LaroscainRepository.Interfaces;
using IPT102LaroscainDomain.Models;
using IPT102LaroscainFramework.Repositories; // Para sa BaseRepository
using Dapper;
using System.Data;

namespace IPT102LaroscainRepository.Services
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString) : base(connectionString) { }

        public List<Employee> GetAll()
        {
            using var db = CreateConnection();
            return db.Query<Employee>("spEmployee_GetAll", commandType: CommandType.StoredProcedure).ToList();
        }

        public void Add(Employee employee)
        {
            using var db = CreateConnection();
            db.Execute("spEmployee_Add", new { employee.Name, employee.Position, employee.Salary }, commandType: CommandType.StoredProcedure);
        }

        public void Update(Employee employee)
        {
            using var db = CreateConnection();
            db.Execute("spEmployee_Update", new { employee.Id, employee.Name, employee.Position, employee.Salary }, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            using var db = CreateConnection();
            db.Execute("spEmployee_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public Employee GetById(int id)
        {
            using var db = CreateConnection();
            return db.QueryFirstOrDefault<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
        }
    }
}