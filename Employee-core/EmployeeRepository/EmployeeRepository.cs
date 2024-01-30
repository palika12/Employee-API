
using Employee_core.Data;
using Employee_core.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_core.IEmployeeRepository
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees
                .Include(e => e.Salary)
             
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dbContext.Employees
                .Include(e => e.Salary)
             
                .FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);

            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = updatedEmployee.EmployeeName;
                existingEmployee.Age = updatedEmployee.Age;

                await _dbContext.SaveChangesAsync();
            }

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employeeToDelete = await _dbContext.Employees.FindAsync(id);

            if (employeeToDelete != null)
            {
                _dbContext.Employees.Remove(employeeToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
            public async Task<bool> EmployeeExists(int id)
            {
                return await _dbContext.Employees.AnyAsync(e => e.Id == id);
            }
        }
    }

