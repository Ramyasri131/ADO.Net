using EmployeeDirectory.DAL.Models;
using System.Data.SqlClient;
namespace EmployeeDirectory.DAL.StaticData
{
    public static class Constants
    {
        public static Dictionary<int, string> Departments = new()
        {
          {1,"PE" },
          {2,"Testing" },
          {3,"Marketing" }
        };

        public static Dictionary<int, string> Projects = new()
        {
           {1,"Project1" },
           {2,"Project2" },
           {3,"Project3" }
        };

        public static Dictionary<int, string> Managers = new()
        {
            {1,"Sandeep" },
            {2,"Siva" },
            {3,"Shashank" }
        };

        public static Dictionary<int, string> Locations = new()
        {
            {1,"Hyderabad" },
            {2,"Banglore" },
            {3,"Vizag" }
        };

        public static Dictionary<int, string> EmployeeDataLabels = new()
        {
           {1,"FirstName" },
           {2,"LastName" },
           {3,"Email" },
           {4,"MobileNumber" },
           {5, "DateOfBirth" },
           {6,"DateOfJoin" },
           {7,"Location" },
           {8,"JobTitle" },
           {9,"Department" },
           {10,"Manager" },
           {11,"Project" }
        };

        public static Dictionary<int, string> MainMenu = new()
        {
            {1,"Employee Management" },
            {2,"Role Management" },
            {3,"Exit" }
        };
        
        public static Dictionary<int, string> EmployeeManagementMenu = new()
        {
            {1,"Add employee" },
            {2,"Display All" },
            {3,"Display One"},
            {4,"Edit employee"},
            {5,"Delete employee"},
            {6,"Go Back"}
        };

        public static Dictionary<int, string> RoleManagementMenu = new()
        {
            {1,"Add Role" },
            {2,"Display All" },
            {3,"Go Back" }
        };

        public static Dictionary<int, string> Roles = new()
        {
        };

        public static int i = 1;

        public static void GetRoles()
        {
            List<string> rolesData = new();
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
                        Department = reader["Department"].ToString()!,
                        Description = reader["Description"].ToString()
                    };
                    roleList.Add(role);
                }
                foreach (Role item in roleList)
                {
                    rolesData.Add(item.Name!);
                }
                foreach (string roleName in rolesData)
                {
                    Roles.Add(i, roleName);
                    i++;
                }
            }
        }
    }
}