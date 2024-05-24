using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Repository
{
    public  class DepartmentRepository: IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public Dictionary<int, string>  GetDepartments()
        {
            Dictionary<int, string> departments=new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Departments", connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    departments.Add(int.Parse(sqlDataReader["Dept_Id"].ToString()!), sqlDataReader["Dept_Name"].ToString()!);
                }
            }
            return departments;
        }
    }
}