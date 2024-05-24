using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace EmployeeDirectory.DAL.Repository
{
    public class ManagerRepository:IManagerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public Dictionary<int, string> GetManagers()
        {
            Dictionary<int, string> managers = new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Manager", connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    managers.Add(int.Parse(sqlDataReader["Manager_Id"].ToString()!), sqlDataReader["Manager_Name"].ToString()!);
                }
            }
            return managers;
        }
    }
}