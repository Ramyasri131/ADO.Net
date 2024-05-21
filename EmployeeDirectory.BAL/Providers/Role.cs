using EmployeeDirectory.BAL.Exceptions;
using EmployeeDirectory.DAL.Data;
using EmployeeDirectory.DAL.Extensions;
using EmployeeDirectory.DAL.Exceptions;

namespace EmployeeDirectory.BAL.Providers
{
    public static class Role
    {
        public static void AddRole(DAL.Models.Role roleInput)
        {
            if(roleInput.Name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidData("Enter Role Name");
            }
            List<DAL.Models.Role> inputRoleData;
            inputRoleData = RoleHandler.GetRoleDetails();
            foreach (DAL.Models.Role role in inputRoleData)
            {
                if(role.Name == roleInput.Name)
                {
                    throw new InvalidData("Role Exists");
                }
            }
            RoleHandler.WriteRoleData(roleInput);
        }

        public static List<DAL.Models.Role> GetRoles()
        {
            List<DAL.Models.Role> roles = RoleHandler.GetRoleDetails();
            if (roles.Count == 0)
            {
                throw new RecordNotFound("Data Base is empty");
            }
            else
            {
                return roles;
            }
        }
    }
}