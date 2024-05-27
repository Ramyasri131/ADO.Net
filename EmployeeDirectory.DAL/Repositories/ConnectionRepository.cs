using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Repository
{
    public class ConnectionRepository(IConfiguration configuration) : IConnectionRepository
    {
        public readonly string _connectionString = configuration.GetConnectionString("EmployeeDirectoryDB");

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
