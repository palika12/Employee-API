
using Employee_core.IEmployeeRepository;
using Employee_core.IEmployeeService;
using Employee_core.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_core.EmployeeService
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId)
        {
            return await _salaryRepository.GetSalaryByEmployeeIdAsync(employeeId);
        }



        public async Task<Salary> AddSalaryAsync(Salary salary)
        {
            // You can add additional validation logic here if needed
            var existingSalary = await _salaryRepository.GetSalaryByEmployeeIdAsync(salary.EmployeeId);

            if (existingSalary != null)
            {
                throw new ArgumentException("Salary for the employee already exists.");
            }

            return await _salaryRepository.AddSalaryAsync(salary);
        }


        public async Task<Salary> UpdateSalaryAsync(int employeeId, Salary updatedSalary)
        {
            var existingSalary = await _salaryRepository.GetSalaryByEmployeeIdAsync(employeeId);

            if (existingSalary == null)
            {
                throw new ArgumentException("Salary not found");
            }

         
            existingSalary.Amount = updatedSalary.Amount;
          

            return await _salaryRepository.UpdateSalaryAsync(employeeId, existingSalary);
        }

        public async Task<bool> DeleteSalaryAsync(int employeeId)
        {
            var existingSalary = await _salaryRepository.GetSalaryByEmployeeIdAsync(employeeId);

            if (existingSalary == null)
            {
                throw new ArgumentException("Salary not found");
            }

            return await _salaryRepository.DeleteSalaryAsync(employeeId);
        }
    }
}
