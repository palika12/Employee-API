using Employee_core.IEmployeeService;
using Employee_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_core.Controllers
{
    [ApiController]
    [Route("api/salaries")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Salary>> GetSalaryByEmployeeId(int employeeId)
        {
            var salary = await _salaryService.GetSalaryByEmployeeIdAsync(employeeId);

            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }

        [HttpPost]
        public async Task<ActionResult<Salary>> AddSalary(Salary salary)
        {
            try
            {
                var addedSalary = await _salaryService.AddSalaryAsync(salary);
                return CreatedAtAction(nameof(GetSalaryByEmployeeId), new { employeeId = addedSalary.EmployeeId }, addedSalary);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error adding salary: {ex.Message}");
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateSalary(int employeeId, Salary updatedSalary)
        {
            try
            {
                var result = await _salaryService.UpdateSalaryAsync(employeeId, updatedSalary);

                if (result == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error updating salary: {ex.Message}");
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteSalary(int employeeId)
        {
            try
            {
                var result = await _salaryService.DeleteSalaryAsync(employeeId);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error deleting salary: {ex.Message}");
            }
        }
    }
}

