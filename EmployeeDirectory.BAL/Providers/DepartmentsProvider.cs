using EmployeeDirectory.DAL.Interfaces;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{

    public class DepartmentsProvider(IDepartmentRepository DepartmentRepository) : IDepartmentProvider
    {
        public static Dictionary<int, string> Departments = new();
        private readonly IDepartmentRepository _DepartmentRepository = DepartmentRepository;

        public void GetDepartments()
        {
            Departments = _DepartmentRepository.GetDepartments();
        }

    }
}
