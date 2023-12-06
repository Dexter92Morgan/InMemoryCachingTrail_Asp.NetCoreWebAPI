using InMemoryCache.Services.Cache.CacheInterface;
using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Helpers;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryCache.API.Controllers
{
    [Route("")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger _logger;
        private readonly ICacheProvider _cacheProvider;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger,ICacheProvider cacheProvider)
        {
            _employeeService = employeeService;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employeeRequestDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("employee")]
        public async Task<IActionResult> AddEmployee(EmployeeRequestDto employeeRequestDto)
        {
            _logger.LogInformation("Adding Employee: {employeename}", employeeRequestDto.FullName);
            var employeeAdded = await _employeeService.AddEmployee(employeeRequestDto);
            if (employeeAdded != null)
            {
                _logger.LogInformation("{success} : Employee :{employee}", Messages.EmployeeRegisterSuccess, employeeRequestDto.FullName);
                return Ok(new { message = Messages.EmployeeRegisterSuccess, employeename = employeeAdded, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Employee :{employee}", Messages.EmployeeRegisterError, employeeRequestDto.FullName);
                return BadRequest(new { message = Messages.EmployeeRegisterError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("employee")]
        public async Task<IActionResult> GetAllEmployees()
        {
            _logger.LogInformation("Get All Employees");
            var employees = await _employeeService.GetAllEmployeeAsync();
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Get all Employees from Cache
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("employeecache")]
        public async Task<IActionResult> GetAllEmployeesCacheResponse()
        {
            _logger.LogInformation("Get All Employees");
            var employees = await _cacheProvider.GetCachedResponse();
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }
        /// <summary>
        /// Get Employees by Id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("employee/{employeeid}")]
        public async Task<IActionResult> GetEmployeesById(int employeeid)
        {
            _logger.LogInformation("Get Employees by Id : {id}", employeeid);
            var employees = await _employeeService.GetEmployeeByIdAsync(employeeid);
            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return BadRequest(new { message = Messages.NoData, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employeeRequestUpdateDto">Employee update request</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Route("employee/{employeeid}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequestUpdateDto employeeRequestUpdateDto, int employeeid)
        {
            _logger.LogInformation("Updating Employee : Employee Name: {employee}", employeeRequestUpdateDto.FullName);
            var updatedEmployee = await _employeeService.UpdateEmployee(employeeRequestUpdateDto, employeeid);
            if (updatedEmployee)
            {
                _logger.LogInformation("{success} : Employee Name: {employee}", Messages.EmployeeUpdateSuccess, employeeRequestUpdateDto.FullName);
                return Ok(new { message = Messages.EmployeeUpdateSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Employee Name: {employee}", Messages.EmployeeUpdateError, employeeRequestUpdateDto.FullName);
                return BadRequest(new { message = Messages.EmployeeUpdateError, currentDate = DateTime.Now });
            }
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="employeeid">Employee id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        [Route("employee/{employeeid}")]
        public async Task<IActionResult> DeleteEmployee(int employeeid)
        {
            _logger.LogInformation("Deleing Employee : Employee Id: {employee}", employeeid);
            var deletedEmployee = await _employeeService.DeleteEmployee(employeeid);
            if (deletedEmployee)
            {
                _logger.LogInformation("{success} : Employee Id: {employee}", Messages.EmployeeDeleteSuccess, employeeid);
                return Ok(new { message = Messages.EmployeeDeleteSuccess, currentDate = DateTime.Now });
            }
            else
            {
                _logger.LogInformation("{error} : Employee Id: {employee}", Messages.EmployeeDeleteError, employeeid);
                return BadRequest(new { message = Messages.EmployeeDeleteError, currentDate = DateTime.Now });
            }
        }
    }
}
