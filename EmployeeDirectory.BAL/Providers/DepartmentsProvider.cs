using EmployeeDirectory.DAL.Interfaces;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{

    public class DepartmentsProvider: IDepartmentProvider
    {
        public static Dictionary<int, string> Departments = new();
        private readonly IDepartmentRepository _DepartmentRepository;

        public DepartmentsProvider(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public void GetDepartments()
        {
            Departments = _DepartmentRepository.GetDepartments();
        }

    }
}
