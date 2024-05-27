using EmployeeDirectory.BAL.Interfaces;
using EmployeeDirectory.DAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{
    public class ProjectsProvider(IProjectRepository ProjectRepository) : IProjectProvider
    {
        public static Dictionary<int, string> Projects = new();
        private readonly IProjectRepository _ProjectRepository = ProjectRepository;

        public void GetProjects()
        {
            Projects = _ProjectRepository.GetProjects();
        }
    }
}
