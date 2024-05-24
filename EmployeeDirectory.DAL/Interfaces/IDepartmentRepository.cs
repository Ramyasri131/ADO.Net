namespace EmployeeDirectory.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        public Dictionary<int, string> GetDepartments();

    }
}
