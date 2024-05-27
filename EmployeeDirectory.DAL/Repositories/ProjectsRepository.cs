using EmployeeDirectory.DAL.Interfaces;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Repository
{
    public class ProjectsRepository(IConnectionRepository connection) : IProjectRepository
    {

        public Dictionary<int, string> GetProjects()
        {
            Dictionary<int, string> projects = new();
            using (SqlConnection sqlConnection = connection.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from Projects", sqlConnection);
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
