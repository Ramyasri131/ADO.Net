using EmployeeDirectory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Data
{
    
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public EmployeeRepository(IConfiguration configuration) {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public  List<Models.Employee> GetEmployeeDetails()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Employee", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Models.Employee> employeeList = new List<Models.Employee>();
            while (reader.Read())
            {
                Models.Employee employee = new()
                {
                    Id = reader["Employee_Id"].ToString()!,
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    DateOfBirth = reader["DateOfBirth"].ToString()!,
                    Manager = reader["Manager"].ToString()!,
                    MobileNumber = Convert.ToInt64(reader["MobileNumber"]),
                    DateOfJoin = reader["DateOfJoin"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Location = reader["Location"].ToString()!,
                    JobTitle = reader["JobTitle"].ToString()!,
                    Department = reader["Department"].ToString()!,
                    Project = reader["Project"].ToString()!
                };
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public  Models.Employee? GetEmployee(string? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from Employee where Employee_Id=@ID;", connection);
                sqlCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Models.Employee employee = new()
                    {
                        Id = reader["Employee_Id"].ToString()!,
                        FirstName = reader["FirstName"].ToString()!,
                        LastName = reader["LastName"].ToString()!,
                        DateOfBirth = reader["DateOfBirth"].ToString()!,
                        Manager = reader["Manager"].ToString()!,
                        MobileNumber = Convert.ToInt64(reader["MobileNumber"]),
                        DateOfJoin = reader["DateOfJoin"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        Location = reader["Location"].ToString()!,
                        JobTitle = reader["JobTitle"].ToString()!,
                        Department = reader["Department"].ToString()!,
                        Project = reader["Project"].ToString()!,
                    };
                    return employee;
                }
                return null;
            }
        }

        public  void InsertEmployee(Models.Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Employee([Employee_Id],[FirstName],[LastName],[Email],[MobileNumber],[DateOfBirth],[DateOfJoin],[Location],[JobTitle],[Department],[Manager],[Project]) values(@Id,@FirstName,@LastName,@Email,@MobileNumber,@DateOfBirth,@DateOfJoin,@Location,@JobTitle,@Department,@Manager,@Project);", connection);
                sqlCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = employee.Id;
                sqlCommand.Parameters.Add("@FirstName",SqlDbType.VarChar).Value = employee.FirstName;
                sqlCommand.Parameters.Add("@LastName",SqlDbType.VarChar).Value = employee.LastName;
                sqlCommand.Parameters.Add("@Email",SqlDbType.VarChar).Value = employee.Email;
                sqlCommand.Parameters.Add("@MobileNumber",SqlDbType.BigInt).Value = employee.MobileNumber;
                sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = DateTime.Parse(employee.DateOfBirth);
                sqlCommand.Parameters.Add("@DateOfJoin", SqlDbType.Date).Value = DateTime.Parse(employee.DateOfJoin);
                sqlCommand.Parameters.Add("@Location", SqlDbType.Int).Value = employee.Location;
                sqlCommand.Parameters.Add("@JobTitle", SqlDbType.Int).Value = employee.JobTitle;
                sqlCommand.Parameters.Add("@Department", SqlDbType.Int).Value = employee.Department;
                sqlCommand.Parameters.Add("@Manager", SqlDbType.Int).Value = employee.Manager;
                sqlCommand.Parameters.Add("@Project", SqlDbType.Int).Value = employee.Project;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public  void UpdateEmployee(string selectedData, string? id, string label)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"update Employee set {label}=@selectedData where Employee_Id=@Id;", connection);
                cmd.Parameters.Add("@selectedData", SqlDbType.VarChar).Value = selectedData;
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value =id;
                cmd.ExecuteNonQuery();
            }
        }

        public  void DeleteEmployee(string? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"Delete Employee where Employee_Id=@Id;", connection);
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
            }
        }

    }
}