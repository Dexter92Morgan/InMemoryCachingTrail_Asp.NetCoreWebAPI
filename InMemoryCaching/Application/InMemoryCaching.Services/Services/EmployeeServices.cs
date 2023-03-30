using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Exceptions;
using InMemoryCaching.Domain.Helpers;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Domain.Models;

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

        public async Task<IEnumerable<EmployeeGetDto>> GetAllEmployeeAsync()
        {
            var result = await _employeeRepository.GetAllEmployeeAsync();

            return result.Select(x => x)
            .Select(x => new EmployeeGetDto
            {
                EmployeeId = x.EmployeeId,
                FullName = x.FullName,
                EmpCode = x.EmpCode,
                Position = x.Position,
                OfficeLocation = x.OfficeLocation
            });
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeid)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeid);
            if (employee == null)
            {
                throw new RepositoryException(Messages.InvalidEmployeeId);
            }
            return employee;
        }

        public async Task<bool> UpdateEmployee(EmployeeRequestUpdateDto employeeRequestUpdateDto, int employeeid)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeid);
            if (employee == null)
            {
                throw new RepositoryException(Messages.InvalidEmployeeId);
            }
            else
            {
                employee.FullName = employeeRequestUpdateDto.FullName;
                employee.EmpCode = employeeRequestUpdateDto.EmpCode;
                employee.Position = employeeRequestUpdateDto.Position;
                employee.OfficeLocation = employeeRequestUpdateDto.OfficeLocation;
                var retval = await _employeeRepository.UpdateEmployee(employee, employeeid);
                return retval;
            }
        }

        public async Task<bool> DeleteEmployee(int employeeid)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeid);
            if (employee == null)
            {
                throw new RepositoryException(Messages.InvalidEmployeeId);
            }
            return await _employeeRepository.DeleteEmployee(employeeid);
        }

    }
}
