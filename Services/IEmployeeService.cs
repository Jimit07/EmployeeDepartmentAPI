using EmployeeDepartmentAPI.Models.DTO;

namespace EmployeeDepartmentAPI.Services
{
    public interface IEmployeeService
    {
        List<ShowEmployeeDto> GetAllEmployee();

        ShowEmployeeDto AddEmployee(AddEmployeeDto addEmployeedto);

        ShowEmployeeDto UpdateEmployee(int id,UpdateEmployeeDto updateemployeedto);

        bool DeleteEmployee(int id);
    }
}
