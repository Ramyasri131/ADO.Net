namespace EmployeeDirectory.DAL.Interfaces
{
    public interface IRoleRepository
    {
        public List<Models.Role> GetRoles();

        public void AddRole(Models.Role role);

        public Dictionary<int, string> GenerateRoleList();
    }
}
