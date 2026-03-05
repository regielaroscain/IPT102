using Domain.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration; // Importante ito para sa JSON
using System.IO;

namespace Framework.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string GetConnectionString()
        {
            // Binabasa ang appsettings.json mula sa folder kung nasaan ang application
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand("spEmployee_GetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Position = reader["Position"].ToString(),
                            Department = reader["Department"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Employee emp)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand("spEmployee_Create", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@Position", (object)emp.Position ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@Department", (object)emp.Department ?? System.DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee emp)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand("spEmployee_Update", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@Position", (object)emp.Position ?? System.DBNull.Value);
                cmd.Parameters.AddWithValue("@Department", (object)emp.Department ?? System.DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                var cmd = new SqlCommand("spEmployee_Delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}