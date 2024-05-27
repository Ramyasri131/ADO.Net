using EmployeeDirectory.Utilities;
using EmployeeDirectory.DAL.StaticData;
using EmployeeDirectory.Interfaces;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.BAL.Exceptions;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.Manager
{
   
    public class Menu : IMenuManager
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IRoleProvider _roleProvider;
        private readonly IDepartmentProvider _departmentProvider;
        private readonly ILocationProvider _locationProvider;
        private readonly IManagerProvider _managerProvider;
        private readonly IProjectProvider _projectProvider;


        public Menu(IEmployeeService employeeService, IRoleService roleService, IRoleProvider roleProvider, IDepartmentProvider departmentProvider, ILocationProvider locationProvider, IManagerProvider managerProvider, IProjectProvider projectProvider)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _roleProvider = roleProvider;
            _departmentProvider = departmentProvider;
            _locationProvider = locationProvider;
            _managerProvider = managerProvider;
            _projectProvider = projectProvider;
        }

        public void DisplayMainMenu()
        {
            _departmentProvider.GetDepartments();
            _locationProvider.GetLocations();
            _managerProvider.GetManagers();
            _projectProvider.GetProjects();
            _roleProvider.GenerateRoleList();
            Display.Print("Main Menu");
            foreach (var item in Constants.MainMenu)
            {
                Display.Print(item.Key, item.Value);
            }
            Display.Print("");
            Display.Print("Enter Your Choice:");
            string? enteredOption = Console.ReadLine();
            try
            {
                int selectedOption = int.Parse(enteredOption!);
                switch (selectedOption)
                {
                    case 1:
                        DisplayEmployeeManagementMenu();
                        break;
                    case 2:
                        DisplayRoleManagementMenu();
                        break;
                    case 3:
                        Display.Print("Exit");
                        return;
                    default:
                        Display.Print("Invalid Option");
                        break;
                }
            }
            catch (FormatException)
            {
                Display.Print("Enter valid option");
                DisplayMainMenu();
            }
        }

        public void DisplayEmployeeManagementMenu()
        {
            Display.Print("Employee Management");
            foreach (var item in Constants.EmployeeManagementMenu)
            {
                Display.Print(item.Key, item.Value);
            }
            Display.Print("");
            Display.Print("Enter your choice:");
            string? enteredValue = Console.ReadLine();
            try
            {
                int selectedOption = int.Parse(enteredValue!);
                switch (selectedOption)
                {
                    case 1:
                        _employeeService.GetEmployee();
                        break;
                    case 2:
                        _employeeService.DisplayEmployees();
                        break;
                    case 3:
                        _employeeService.DisplayEmployee();
                        break;
                    case 4:
                        _employeeService.EditEmployee();
                        break;
                    case 5:
                        _employeeService.DeleteEmployee();
                        break;
                    case 6:
                        DisplayMainMenu();
                        return;
                    default:
                        Display.Print("Enter valid option");
                        break;
                }
            }
            catch(FormatException)
            { 
                Display.Print("Enter Integer value");
            }
            catch(RecordNotFound ex)
            {
                Display.Print(ex.Message);
            }
            catch (InvalidData ex)
            {
                Display.Print(ex.Message);

            }
            finally
            {
                DisplayEmployeeManagementMenu();
            }
        }

        public void DisplayRoleManagementMenu()
        {
            Display.Print("Role Management");
            foreach (var item in Constants.RoleManagementMenu)
            {
                Display.Print(item.Key, item.Value);
            }
            Display.Print("");
            Display.Print("Enter your choice:");
            string? enteredValue = Console.ReadLine();
            try
            {
                int selectedOption = int.Parse(enteredValue!);
                switch (selectedOption)
                {
                    case 1:
                        _roleService.GetRoles();
                        break;
                    case 2:
                        _roleService.DisplayRoles();
                        break;
                    case 3:
                        DisplayMainMenu();
                        break;
                    default:
                        Display.Print("Invalid Option");
                        break;
                }
            }
            catch (FormatException )
            {
                Display.Print("Enter Integer value");
            }
            catch (RecordNotFound ex)
            {
                Display.Print(ex.Message);
            }
            catch (InvalidData ex)
            {
                Display.Print(ex.Message);
            }
            finally
            {
                DisplayRoleManagementMenu();
            }
        }
    }
}