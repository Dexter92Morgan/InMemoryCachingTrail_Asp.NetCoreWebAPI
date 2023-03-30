using InMemoryCaching.Domain.Models;

namespace InMemoryCaching.Domain.Interfaces.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        public Task<bool> AddEmployee(Employee employee);
        public Task<Employee> GetEmployeeByIdAsync(int employeeid);
        public Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        public Task<bool> UpdateEmployee(Employee employeeUpdate, int employeeid);
        public Task<bool> DeleteEmployee(int employeeid);
    }

}
