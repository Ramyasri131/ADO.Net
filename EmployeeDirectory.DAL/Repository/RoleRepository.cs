using EmployeeDirectory.DAL.Interfaces;
using EmployeeDirectory.DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Data
{
    public class RoleRepository: IRoleRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public RoleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDirectoryDB");
        }

        public List<Models.Role> GetRoles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Roles", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Models.Role> roleList = new List<Models.Role>();
                while (reader.Read())
                {
                    Models.Role role = new()
                    {
                        Id = int.Parse(reader["Role_Id"].ToString()!),
                        Name = reader["Role_Name"].ToString(),
                        Location = int.Parse(reader["Location"].ToString()!),
                        Department= int.Parse(reader["Department"].ToString()!),
                        Description = reader["Description"].ToString()
                    };
                    roleList.Add(role);
                }
                return roleList;
            }
        }

        public void AddRole(Role role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"insert into roles([Role_Id],[Role_Name],[Location],[Department],[Description])" +
                    $" values(@Id,@Name,@Location,@Department,@Description)", connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value =role.Id;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value =role.Name;
                command.Parameters.Add("@Location", SqlDbType.VarChar).Value =role.Location;
                command.Parameters.Add("@Department", SqlDbType.VarChar).Value =role.Department;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value =role.Description;
                command.ExecuteNonQuery();
            }
        }

        public Dictionary<int, string> GenerateRoleList()
        {
            Dictionary<int, string> roles=new();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Role_Id,Role_Name from Roles", connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    roles.Add(int.Parse(sqlDataReader["Role_Id"].ToString()!), sqlDataReader["Role_Name"].ToString()!);
                }
            }
            return roles;
        }

    }
}