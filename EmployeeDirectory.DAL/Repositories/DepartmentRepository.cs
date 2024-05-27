using EmployeeDirectory.DAL.Interfaces;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Repository
{
    public  class DepartmentRepository(IConnectionRepository connection) : IDepartmentRepository
    {

        public Dictionary<int, string>  GetDepartments()
        {
            Dictionary<int, string> departments=new();
            using (SqlConnection sqlConnection= connection.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from Departments", sqlConnection);
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