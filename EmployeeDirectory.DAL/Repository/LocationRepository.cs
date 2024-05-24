using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace EmployeeDirectory.DAL.Repository
{
    public class LocationRepository: ILocationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public Dictionary<int, string> GetLocations()
        {
            Dictionary<int, string> locations = new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Location", connection);
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