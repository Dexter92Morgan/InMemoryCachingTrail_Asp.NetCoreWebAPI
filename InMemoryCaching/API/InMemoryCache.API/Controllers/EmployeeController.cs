using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Helpers;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using Microsoft.AspNetCore.Http;
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

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
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
                return Ok(new {message = Messages.EmployeeRegisterSuccess, employeename = employeeAdded, currentDate = DateTime.Now});
            }
            else
            {
                _logger.LogInformation("{error} : Employee :{employee}", Messages.EmployeeRegisterSuccess, employeeRequestDto.FullName);
                return BadRequest(new { message = Messages.EmployeeRegisterError, currentDate = DateTime.Now });
            }
        }
    }
}
