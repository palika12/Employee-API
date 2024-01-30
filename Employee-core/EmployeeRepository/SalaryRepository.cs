using Employee_core.Data;
using Employee_core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Employee_core.IEmployeeRepository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public SalaryRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public async Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId)
        {
            return await _dbContext.Salaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
        }

        public async Task<Salary> AddSalaryAsync(Salary salary)
        {
            _dbContext.Salaries.Add(salary);
            await _dbContext.SaveChangesAsync();
            return salary;
        }

        public async Task<Salary> UpdateSalaryAsync(int employeeId, Salary updatedSalary)
        {
            var existingSalary = await _dbContext.Salaries.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);

            if (existingSalary != null)
            {
                existingSalary.Amount = updatedSalary.Amount;
                

                await _dbContext.SaveChangesAsync();
            }

            return existingSalary;
        }

        public async Task<bool> DeleteSalaryAsync(int employeeId)
        {
            var salaryToDelete = await _dbContext.Salaries.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);

            if (salaryToDelete != null)
            {
                _dbContext.Salaries.Remove(salaryToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
