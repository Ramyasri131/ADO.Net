using EmployeeDirectory.DAL.Models;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Text.Json;

namespace EmployeeDirectory.DAL.Data
{
    public static class EmployeeHandler
    {
        public static List<Models.Employee> GetEmployeeDetails()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select *from Employee", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Models.Employee> employeeList = new List<Models.Employee>();
            while (reader.Read())
            {
                Models.Employee employee = new()
                {
                    Id = reader["Id"].ToString()!,
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
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public static Models.Employee GetEmployee(string? id)
        {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from Employee where Id='{id}';", sq);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Models.Employee employee = null;
                while (reader.Read())
                {
                     employee = new()
                    {
                        Id = reader["Id"].ToString()!,
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
                }
                return employee;
            }
        }
        public static void InsertEmployee(Models.Employee employee)
        {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Employee([Id],[FirstName],[LastName],[Email],[MobileNumber],[DateOfBirth],[DateOfJoin],[Location],[JobTitle],[Department],[Manager],[Project]) values('{employee.Id}','{employee.FirstName}','{employee.LastName}','{employee.Email}',{employee.MobileNumber},'{employee.DateOfBirth}','{employee.DateOfJoin}','{employee.Location}','{employee.JobTitle}','{employee.Department}','{employee.Manager}','{employee.Project}');",sq);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void UpdateEmployee(string selectedData,string id,string label)
        {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand($"update Employee set {label}='{selectedData}' where Id='{id}';",sq);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(string? id) {
            using (SqlConnection sq = new SqlConnection("Server=SQL-Dev;Database=RamyaEmployeeDirectoryDB;Trusted_Connection=True;"))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand($"Delete Employee where Id='{id}';", sq);
                cmd.ExecuteNonQuery();
            }
        }

    }
}