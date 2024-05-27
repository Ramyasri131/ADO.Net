using EmployeeDirectory.DAL.Interfaces;
using System.Data.SqlClient;
namespace EmployeeDirectory.DAL.Repository
{
    public class ManagerRepository(IConnectionRepository connection) : IManagerRepository
    {
        public Dictionary<int, string> GetManagers()
        {
            Dictionary<int, string> managers = new();
            using (SqlConnection sqlConnection = connection.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from Manager", sqlConnection);
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