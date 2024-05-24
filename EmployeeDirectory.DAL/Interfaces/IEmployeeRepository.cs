namespace EmployeeDirectory.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Models.Employee> GetEmployeeDetails();

        public Models.Employee? GetEmployee(string? id);

        public void InsertEmployee(Models.Employee employee);

        public void UpdateEmployee(string selectedData, string? id, string label);

        public void DeleteEmployee(string? id);

    }
}
