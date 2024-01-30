using Employee_core.Models;

namespace Employee_core.IEmployeeRepository
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> EmployeeExists(int id);
    }
}
