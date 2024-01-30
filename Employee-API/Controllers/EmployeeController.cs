using Employee_core.IEmployeeService;
using Employee_core.Models;
using Microsoft.AspNetCore.Mvc;
namespace Employee_core.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpService _employeeService;
        private readonly ISalaryService _salaryService;

        public EmployeeController(IEmpService employeeService, ISalaryService salaryService)
        {
            _employeeService = employeeService;
            _salaryService = salaryService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("addemployee")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = await _employeeService.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.Id }, addedEmployee);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error adding employee: {ex.Message}");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while adding an employee.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmployee)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeAsync(id, updatedEmployee);

                if (result == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error updating employee: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployeeAsync(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error deleting employee: {ex.Message}");
            }
        }
        [HttpGet("{id}/salary")]
        public async Task<ActionResult<Salary>> GetSalaryByEmployeeId(int id)
        {
            try
            {
               
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound("Employee not found");
                }

                
                var salary = await _salaryService.GetSalaryByEmployeeIdAsync(id);

                if (salary == null)
                {
                    return NotFound("Salary details not found");
                }

                return Ok(salary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

