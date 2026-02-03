using System.Data;
using Microsoft.Data.SqlClient;

namespace IPT102LaroscainFramework.Repositories;

public abstract class BaseRepository
{
    private readonly string _connectionString;

    // Ito ang constructor na tumatanggap ng 1 argument (ang string)
    public BaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Ito ang method na hinahanap ng EmployeeRepository mo
    protected IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}