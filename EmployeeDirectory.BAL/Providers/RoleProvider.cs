using EmployeeDirectory.BAL.Exceptions;
using EmployeeDirectory.DAL.Extensions;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.DAL.Interfaces;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{
    public class RoleProvider:IRoleProvider
    {
        public static Dictionary<int, string> Roles = new();
        private readonly IRoleRepository _roleRepository;

        public RoleProvider(IRoleRepository roleRepository) {
            _roleRepository = roleRepository;
        }

        public void AddRole(DTO.Role roleInput)
        {
            if(roleInput.Name.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidData("Enter Role Name");
            }
            List<DAL.Models.Role> RoleData= _roleRepository.GetRoles().OrderBy(x => x.Id).ToList();
            foreach (DAL.Models.Role role in RoleData)
            {
                if(role.Name == roleInput.Name)
                {
                    throw new InvalidData("Role Exists");
                }
            }
            int id = RoleData[^1].Id + 1;
            DAL.Models.Role user = new()
            {
                Id=id,
                Name= roleInput.Name,
                Location= roleInput.Location,
                Department=roleInput.Department,
                Description= roleInput.Description
            };
            _roleRepository.AddRole(user);
        }

        public  List<DTO.Role> GetRoles()
        {
            List<DAL.Models.Role> roles = _roleRepository.GetRoles();
            List<DTO.Role> viewRoles = new();
            foreach(DAL.Models.Role item in roles)
            {
                DTO.Role user = new()
                {
                   Name = item.Name,
                   Location = item.Location,
                   Department = item.Department,
                   Description = item.Description
                };

                viewRoles.Add(user);
            }
           
            if (roles.Count == 0)
            {
                throw new RecordNotFound("Data Base is empty");
            }
            else
            {
                return viewRoles;
            }
        }


        public  void GenerateRoleList()
        {
            Roles = _roleRepository.GenerateRoleList();
        }

    }
}