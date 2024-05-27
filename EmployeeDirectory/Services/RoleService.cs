using EmployeeDirectory.Utilities;
using EmployeeDirectory.Interfaces;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.BAL.Providers;
using EmployeeDirectory.BAL.Interfaces;
using EmployeeDirectory.BAL.Extensions;

namespace EmployeeDirectory.Services
{
    public class RoleService(IRoleProvider roleProvider) : IRoleService
    {

        private readonly IRoleProvider _roleProvider = roleProvider;

        public void GetRoles()
        {
            try
            {
                List<string> InvalidData=new();
                Display.Print("Enter RoleName");
                string? roleName = Console.ReadLine();
                Display.Print("select department");
                int departmentId = GetDetails("department", DepartmentsProvider.Departments);
                Display.Print("Enter Description");
                string? description = Console.ReadLine();
                Display.Print("Select Location");
                int locationId = GetDetails("location", LocationProvider.Location);
                BAL.DTO.Role roleInput;
                if (roleName.IsNullOrEmptyOrWhiteSpace())
                {
                    InvalidData.Add("RoleName");
                }
                if (departmentId > DepartmentsProvider.Departments.Count)
                {
                    InvalidData.Add("Department");
                }
                if (locationId > LocationProvider.Location.Count)
                {
                    InvalidData.Add("Location");
                }
                if (InvalidData.Count == 0)
                {
                    roleInput = new()
                    {
                        Name = roleName,
                        Location = locationId,
                        Department = departmentId,
                        Description = description
                    };
                    _roleProvider.AddRole(roleInput);
                }
                else
                {
                    foreach (string input in InvalidData)
                    {
                        Display.Print($"Enter Valid {input}");
                    }
                    GetRoles();
                }
            }
            catch (FormatException)
            {
                throw;
            }
            catch (BAL.Exceptions.InvalidData)
            {
                throw;
            }
        }

        public static int GetDetails(string label, Dictionary<int, string> list)
        {
            foreach (KeyValuePair<int, string> item in list)
            {
                Display.Print(item.Key + " " + item.Value);
            }
            int selectedKey;
            selectedKey = int.Parse(Console.ReadLine()!);
            return selectedKey;
        }

        public void DisplayRoles()
        {
            List<BAL.DTO.Role>? roleData;
            try
            {
                roleData = _roleProvider.GetRoles();
                Display.PrintRoleData(roleData);
            }
            catch(RecordNotFound)
            {
                throw;
            }
           
        }
    }
}