using System.Data;
using EmployeeDirectory.BAL.Exceptions;
using EmployeeDirectory.BAL.Extensions;
using EmployeeDirectory.DAL.Exceptions;
using EmployeeDirectory.DAL.Interfaces;
using EmployeeDirectory.BAL.Interfaces;

namespace EmployeeDirectory.BAL.Providers
{
   
    public class EmployeeProvider:IEmployeeProvider
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeProvider(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(DTO.Employee employee)
        {
            List<DAL.Models.Employee> employees;
            employees = _employeeRepository.GetEmployeeDetails().OrderBy(x => x.Id).ToList();
            int employeeCount = int.Parse(employees[^1].Id[2..]) + 1;
            string id = string.Format("{0:0000}", employeeCount);
            id = "TZ" + id;
            DAL.Models.Employee user = new()
            {
                Id = id,
                FirstName = employee.FirstName!,
                LastName = employee.LastName!,
                DateOfBirth = employee.DateOfBirth!,
                Manager = employee.Manager,
                MobileNumber = employee.MobileNumber,
                DateOfJoin = employee.DateOfJoin!,
                Email = employee.Email!,
                Location = employee.Location,
                JobTitle = employee.JobTitle,
                Department = employee.Department,
                Project = employee.Project,
            };
            _employeeRepository.InsertEmployee(user);
        }

        public List<DAL.Models.Employee> GetEmployees()
        {
            List<DAL.Models.Employee> employees;
            employees = _employeeRepository.GetEmployeeDetails();
            if (employees.Count == 0)
            {
                throw new RecordNotFound("Data Base is empty");
            }
            else
            {
                return employees;
            }
        }

        public void EditEmployeeDetails(string selectedData, string? id, string label)
        {
         
            if (id.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidData("Enter Employee Id");
            }
            else if (IsEmployeePresent(id))
            {
                id = id?.ToUpper();
                DAL.Models.Employee? employee = _employeeRepository.GetEmployee(id);
                _employeeRepository.UpdateEmployee(selectedData, id, label);
            }
            else
            {
                throw new RecordNotFound("Employee not found");
            }
        }

        public  void DeleteEmployee(string? id)
        {
            if (id.IsNullOrEmptyOrWhiteSpace())
            {
                throw new BAL.Exceptions.InvalidData("Invalid Employee Id");
            }
            else if(IsEmployeePresent(id))
            {
                _employeeRepository.DeleteEmployee(id);
            }
            else
            {
                throw new RecordNotFound("Employee not found");
            }
        }

        public DAL.Models.Employee? GetEmployeeById(string? id)
        {
            if (id.IsNullOrEmptyOrWhiteSpace())
            {
                throw new BAL.Exceptions.InvalidData("Invalid Employee Id");
            }
            else if(IsEmployeePresent(id))
            {
                DAL.Models.Employee? employee = _employeeRepository.GetEmployee(id);
                return employee;
            }
            else
            {
                throw new RecordNotFound("Employee not found");
            }
        }

        public  bool IsEmployeePresent(string? id)
        {
           
                id = id!.ToUpper();
                DAL.Models.Employee? employee = _employeeRepository.GetEmployee(id);
                if (employee is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }
    }
}