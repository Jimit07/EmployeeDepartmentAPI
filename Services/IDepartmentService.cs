using EmployeeDepartmentAPI.Models.DTO;

namespace EmployeeDepartmentAPI.Services
{
    public interface IDepartmentService
    {
        List<ShowDepartmentDto> GetDepartments();
        ShowDepartmentDto AddDepartment(AddDepartmentDto addDepartmentDto);
        ShowDepartmentDto UpdateDepartment(int id ,UpdateDepartmentNameDto updateDepartmentNameDto);
        bool DeleteDepartment(int id);
        

    }
}
