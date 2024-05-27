using EmployeeDirectory.DAL.Interfaces;
using System.Data.SqlClient;


namespace EmployeeDirectory.DAL.Repository
{
    public class LocationRepository(IConnectionRepository connection) : ILocationRepository
    {

        public Dictionary<int, string> GetLocations()
        {
            Dictionary<int, string> locations = new();
            using (SqlConnection sqlConnection = connection.GetConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from Location", sqlConnection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    locations.Add(int.Parse(sqlDataReader["Location_Id"].ToString()!), sqlDataReader["Location_Name"].ToString()!);
                }
            }
            return locations;
        }
    }
}