using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Data
{
    public static class RoleHandler
    {
        public static List<Models.Role> GetRoleDetails()
        {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand("select *from Roles", sq);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Models.Role> roleList = new List<Models.Role>();
                while (reader.Read())
                {
                    Models.Role role = new()
                    {
                        Name = reader["Name"].ToString(),
                        Location = reader["Location"].ToString()!,
                        Department= reader["Department"].ToString()!,
                        Description = reader["Description"].ToString()
                    };
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        public static void WriteRoleData(Models.Role role)
        {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand command = new SqlCommand($"insert into roles([Name],[Location],[Department],[Description]) values('{role.Name}','{role.Location}','{role.Department}','{role.Description}')", sq);
                command.ExecuteNonQuery();
            }
        }
       
    }
}