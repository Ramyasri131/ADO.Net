using EmployeeDirectory.BAL.Interfaces;
using EmployeeDirectory.DAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{
    public class ProjectsProvider: IProjectProvider
    {
        public static Dictionary<int, string> Projects = new();
        private readonly IProjectRepository _ProjectRepository;

        public ProjectsProvider(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        public void GetProjects()
        {
            Projects = _ProjectRepository.GetProjects();
        }
    }
}
