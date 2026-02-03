using IPT102LaroscainDomain.Models;
using Dapper;
using System.Data;

namespace IPT102LaroscainFramework.Queries;

public class GetEmployeeById
{
    // Ito ang tatawag sa Stored Procedure na ginawa mo sa Data project
    public static Employee Execute(IDbConnection db, int id)
    {
        return db.QueryFirstOrDefault<Employee>(
            "GetEmployeeById",
            new { Id = id },
            commandType: CommandType.StoredProcedure);
    }
}