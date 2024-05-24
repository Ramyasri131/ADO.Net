using EmployeeDirectory.Utilities;
using EmployeeDirectory.Interfaces;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.BAL.Providers;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.Services
{
    public class RoleService:IRoleService
    {

        private readonly IRoleProvider _roleProvider;

        public RoleService(IRoleProvider roleProvider) {
            _roleProvider = roleProvider;
        }

        public  void GetRoles()
        {
            Display.Print("Enter RoleName");
            string? roleName = Console.ReadLine();
            BAL.DTO.Role roleInput;
            try
            {
                Display.Print("select department");
                int departmentId = GetDetails("department", DepartmentsProvider.Departments);
                Display.Print("Enter Description");
                string? description = Console.ReadLine();
                Display.Print("Select Location");
                int locationId = GetDetails("location", LocationProvider.Location);
                roleInput = new()
                {
                    Name = roleName,
                    Location = locationId,
                    Department = departmentId,
                    Description = description
                };
                _roleProvider.AddRole(roleInput);
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
            try
            {
                selectedKey = int.Parse(Console.ReadLine()!);
                if( selectedKey > list.Count ) {
                    throw new BAL.Exceptions.InvalidData("Choose the option from the list");
                }
                return selectedKey;
            }
            catch (FormatException)
            {
                throw;
            }
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