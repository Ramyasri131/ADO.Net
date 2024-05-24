using EmployeeDirectory.BAL.Interfaces;
using EmployeeDirectory.DAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{
    public class ManagerProvider: IManagerProvider
    {
        public static Dictionary<int, string> Managers = new();
        private readonly IManagerRepository _ManagerRepository;

        public ManagerProvider(IManagerRepository ManagerRepository)
        {
            _ManagerRepository = ManagerRepository;
        }

        public void GetManagers()
        {
            Managers = _ManagerRepository.GetManagers();
        }
    }
}
