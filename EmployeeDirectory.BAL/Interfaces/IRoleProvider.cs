namespace EmployeeDirectory.BAL.Interfaces
{
    public interface IRoleProvider
    {
        public void AddRole(DTO.Role roleInput);

        public List<DTO.Role> GetRoles();

        public void GenerateRoleList();
    }
}