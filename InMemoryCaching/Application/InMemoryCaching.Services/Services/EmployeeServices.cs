using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCaching.Services.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository; 
        public EmployeeServices(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;    
        }   
        public async Task<string> AddEmployee(EmployeeRequestDto employee)
        {
            var newEmployee = new Employee
            {
                FullName = employee.FullName,
                EmpCode = employee.EmpCode,
                Position = employee.Position,
                OfficeLocation = employee.OfficeLocation,
            };
            var retVal = await _employeeRepository.AddEmployee(newEmployee);

            return retVal ? newEmployee.FullName : null;
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
