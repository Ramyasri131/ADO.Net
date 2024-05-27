using EmployeeDirectory.Utilities;
using EmployeeDirectory.DAL.StaticData;
using EmployeeDirectory.BAL.Validators;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.Interfaces;
using EmployeeDirectory.BAL.Providers;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.Services
{
    public class EmployeeService(IEmployeeProvider employeeProvider) : IEmployeeService
    {
        private readonly IEmployeeProvider _employeeProvider = employeeProvider;

        public void GetEmployee()
        {
            Display.Print("Enter First Name:");
            string? firstName = Console.ReadLine();
            Display.Print("Enter Last Name:");
            string? lastName = Console.ReadLine();
            Display.Print("Enter Date Of Birth in (dd/mm/yyyy):");
            string? dateOfBirth = Console.ReadLine()!;
            Display.Print("Enter Email:");
            string? email = Console.ReadLine();
            Display.Print("Enter Mobile Number:");
            long mobileNumber = long.Parse(Console.ReadLine()!);
            Display.Print("Enter Date Of Join in (dd/mm/yyyy):");
            string? dateOfJoin = Console.ReadLine()!;
            Display.Print("select Location:");
            string location = GetDetails("location", LocationProvider.Location,"Add");
            Display.Print("select JobTitle:");
            string jobTitle = GetDetails("jobTitle", RoleProvider.Roles, "Add");
            Display.Print("select Department:");
            string department = GetDetails("department", DepartmentsProvider.Departments, "Add");
            Display.Print("select Manager");
            string manager = GetDetails("Manager", ManagerProvider.Managers, "Add");
            Display.Print("select Project");
            string project = GetDetails("Project", ProjectsProvider.Projects, "Add");
            BAL.DTO.Employee employeeInput = new()
            {
                FirstName = firstName,                                                                                          
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                MobileNumber = mobileNumber,
                DateOfJoin = dateOfJoin,
                Location = location,
                JobTitle = jobTitle,
                Department = department,
                Manager = manager,
                Project = project
            };
            List<string> InvalidInputs = EmployeeValidator.ValidateDetails(employeeInput);
            if (InvalidInputs.Count == 0)
            {
               _employeeProvider.AddEmployee(employeeInput);
            }
            else
            {
                foreach (string input in InvalidInputs)
                {
                    Display.Print($"Enter Valid {input}");
                }
                GetEmployee();
            }
        }

        public void DisplayEmployees()
        {
            try
            {
                List<DAL.Models.Employee> employeeData = _employeeProvider.GetEmployees();
                Display.PrintEmployeesData(employeeData);
            }
            catch (RecordNotFound)
            {
                throw;
            }
        }

        public void DisplayEmployee()
        {
            Display.Print("Enter Employee Id");
            string? id = Console.ReadLine();
            try
            {
                DAL.Models.Employee? employeeData = _employeeProvider.GetEmployeeById(id);
                Display.PrintEmployeeData(employeeData!);
            }
            catch (RecordNotFound)
            {
                throw;
            }
        }

        public void EditEmployee()
        {
            Display.Print("Enter Employee Id");
            string? id = Console.ReadLine();
            id = id!.ToUpper();
            Display.Print("Field to edit");
            foreach (KeyValuePair<int, string> item in Constants.EmployeeDataLabels)
            {
                Display.Print(item.Key + " " + item.Value);
            }
            Display.Print("Enter Option");
            int selectedOption;
            try
            {
                selectedOption = int.Parse(Console.ReadLine()!);
                string label = Constants.EmployeeDataLabels[selectedOption];
                string? selectedData;
                if (string.Equals(label, "Location"))
                {
                    selectedData = GetDetails(label, LocationProvider.Location,"Edit");
                }
                else if (string.Equals(label, "Department"))
                {
                    selectedData = GetDetails(label, DepartmentsProvider.Departments,"Edit");
                }
                else if (string.Equals(label, "JobTitle"))
                {
                    selectedData = GetDetails(label, RoleProvider.Roles, "Edit");
                }
                else if (string.Equals(label, "Manager"))
                {
                    selectedData = GetDetails(label, ManagerProvider.Managers, "Edit");
                }
                else if (string.Equals(label, "Project"))
                {
                    selectedData = GetDetails(label, ProjectsProvider.Projects, "Edit");
                }
                else if(string.Equals(label, "DateOfJoin") || string.Equals(label, "DateOfJoin"))
                {
                    selectedData = GetValidDetails(label);
                }
                else
                {
                    selectedData = GetValidDetails(label);
                }
                _employeeProvider.EditEmployeeDetails(selectedData, id, label);
            }
            catch (BAL.Exceptions.InvalidData)
            {
                throw;
            }
            catch (RecordNotFound)
            {
                throw;
            }
           
        }

        public static string GetDetails(string label, Dictionary<int, string> list,string operation)
        {
            foreach (KeyValuePair<int, string> item in list)
            {
                Display.Print(item.Key + " " + item.Value);
            }
            string? enteredKey = Console.ReadLine();
            int selectedKey = int.Parse(enteredKey!);
            if (selectedKey <= 0 || selectedKey > list.Count)
            {
                if(string.Equals(operation,"Edit"))
                {
                    EmployeeValidator.ValidateData(label, enteredKey);
                }
            }
            return selectedKey.ToString();
        }

        public static string GetValidDetails(string label)
        {
            Display.Print($"Enter {label}");
            string? inputData = Console.ReadLine()!;
            try
            {
                EmployeeValidator.ValidateData(label,inputData!);
                return inputData;
            }
            catch (BAL.Exceptions.InvalidData)
            {
                throw;
            }
        }

        public void DeleteEmployee()
        {
            Display.Print("Enter Employee Id To Delete");
            string? enteredEmpId = Console.ReadLine();
            try
            {
                _employeeProvider.DeleteEmployee(enteredEmpId);
            }
            catch (RecordNotFound)
            {
                throw;
            }
            catch (BAL.Exceptions.InvalidData)
            {
                throw;
            }
        }
    }
}