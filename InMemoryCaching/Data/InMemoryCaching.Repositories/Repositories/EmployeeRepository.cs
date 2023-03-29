using Dapper;
using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<bool> DeleteEmployee(Employee employeedelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(Employee employeeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
