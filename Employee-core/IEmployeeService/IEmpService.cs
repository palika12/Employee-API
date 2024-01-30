using Employee_core.Models;

namespace Employee_core.IEmployeeService
{
    public interface IEmpService
    { 

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee);
    Task<bool> DeleteEmployeeAsync(int id);
}
}
