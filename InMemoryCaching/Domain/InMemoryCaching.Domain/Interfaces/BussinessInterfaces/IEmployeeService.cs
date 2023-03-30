using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Models;

namespace InMemoryCaching.Domain.Interfaces.BussinessInterfaces
{
    public interface IEmployeeService
    {
        public Task<string> AddEmployee(EmployeeRequestDto employee);
        public Task<Employee> GetEmployeeByIdAsync(int employeeid);
        public Task<IEnumerable<EmployeeGetDto>> GetAllEmployeeAsync();
        public Task<bool> UpdateEmployee(EmployeeRequestUpdateDto employeeRequestUpdateDto, int employeeid);
        public Task<bool> DeleteEmployee(int employeeid);
    }
}
