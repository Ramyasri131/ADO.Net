using System.Data.SqlClient;

namespace EmployeeDirectory.DAL.Interfaces
{
    public interface IConnectionRepository
    {
        public SqlConnection GetConnection();
    }
}
