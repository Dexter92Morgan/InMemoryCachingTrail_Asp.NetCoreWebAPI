using Dapper;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InMemoryCaching.Repositories.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDataAccess _dataAccess;
        public EmployeeRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            int result = 0;
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"INSERT INTO Employees (FullName,EmpCode,Position,OfficeLocation) VALUES (@FullName,@EmpCode,@Position,@OfficeLocation)";
                connection.Open();
                result = await connection.ExecuteAsync(sql, employee);
                connection.Close();
            }
            return result > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM Employees";
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql);
                connection.Close();
                return result;
            }

        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"SELECT * FROM Employees WHERE EmployeeId=@EmployeeId";
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql, new { EmployeeId = employeeid });
                connection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateEmployee(Employee employeeUpdate, int employeeid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"UPDATE Employees Set FullscdName=@FullName,EmpCode=@EmpCode,Position=@Position,OfficeLocation=@OfficeLocation WHERE EmployeeId=@EmployeeId";
                connection.Open();
                await connection.QueryAsync(sql, employeeUpdate);
                connection.Close();
                return true;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeid)
        {
            using (var connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                string sql = @"DELETE FROM Employees WHERE EmployeeId=@EmployeeId";
                connection.Open();
                await connection.QueryAsync(sql, new { EmployeeId = employeeid });
                connection.Close();
                return true;
            }
        }
    }
}
