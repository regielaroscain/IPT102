using Dapper;
using System.Data;

namespace IPT102LaroscainFramework.Commands;

public class CreateEmployee
{
    public static void Execute(IDbConnection db, object employeeParams)
    {
        db.Execute(
            "CreateEmployee",
            employeeParams,
            commandType: CommandType.StoredProcedure);
    }
}