
using Employee_core.IEmployeeRepository;
using Employee_core.IEmployeeService;
using Employee_core.Models;

namespace Employee_core.EmployeeService
{
    public class EmployeeService : IEmpService
    {
        private readonly IEmpRepository _employeeRepository;

        public EmployeeService(IEmpRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return employee;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                var addedEmployee = await _employeeRepository.AddEmployeeAsync(employee);

                if (addedEmployee != null)
                {
                    Console.WriteLine("Employee data added successfully!");
                }

                return addedEmployee;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex}");
                throw;
            }
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            existingEmployee.Id = id;
            existingEmployee.EmployeeName = updatedEmployee.EmployeeName;
            existingEmployee.Age = updatedEmployee.Age;
            
            return await _employeeRepository.UpdateEmployeeAsync(id, existingEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
