using Employee_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_core.IEmployeeService
{
    public interface  ISalaryService
    {
        Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId);
        Task<Salary> AddSalaryAsync(Salary salary);
        Task<Salary> UpdateSalaryAsync(int employeeId, Salary updatedSalary);
        Task<bool> DeleteSalaryAsync(int employeeId);
    }
}
