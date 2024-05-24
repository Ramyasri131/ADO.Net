namespace EmployeeDirectory.BAL.Interfaces
{
    public interface IEmployeeProvider
    {
        public void AddEmployee(DTO.Employee employee);

        public List<DAL.Models.Employee> GetEmployees();

        public void EditEmployeeDetails(string selectedData, string? id, string label);

        public void DeleteEmployee(string? id);

        public DAL.Models.Employee? GetEmployeeById(string? id);

        public bool IsEmployeePresent(string? id);
    }
}
