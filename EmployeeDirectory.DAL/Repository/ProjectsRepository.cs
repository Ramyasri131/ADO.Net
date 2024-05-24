using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Repository
{
    public class ProjectsRepository:IProjectRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ProjectsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public Dictionary<int, string> GetProjects()
        {
            Dictionary<int, string> projects = new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Projects", connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    projects.Add(int.Parse(sqlDataReader["Project_Id"].ToString()!), sqlDataReader["Project_Name"].ToString()!);
                }
            }
            return projects;
        }
    }
}
