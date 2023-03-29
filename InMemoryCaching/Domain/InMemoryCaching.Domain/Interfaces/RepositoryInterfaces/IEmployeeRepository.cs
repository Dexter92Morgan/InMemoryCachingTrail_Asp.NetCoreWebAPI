using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCaching.Domain.Interfaces.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        public Task<bool> AddEmployee(Employee employee);
        public Task<Employee> GetEmployeeByIdAsync(string id);
        public Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        public Task<bool> UpdateEmployee(Employee employeeUpdate);
        public Task<bool> DeleteEmployee(Employee employeedelete);
    }

}
