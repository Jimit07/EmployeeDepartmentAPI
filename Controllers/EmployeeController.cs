using AutoMapper;
using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models;
using EmployeeDepartmentAPI.Models.DTO;
using EmployeeDepartmentAPI.Models.Entities;
using EmployeeDepartmentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Controllers
{
    //localhost:****/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {

            _employeeService = employeeService;

        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employeeDtos = _employeeService.GetAllEmployee();
            return Ok(employeeDtos);

        }

        [HttpPost]



        public IActionResult AddEmployee([FromBody] AddEmployeeDto addEmployeeDto)
        {
            var employeeDto = _employeeService.AddEmployee(addEmployeeDto);
            return Ok(employeeDto);

        }

        [HttpPut("updateEmployee/{id}")]

        public IActionResult UpdateEmployee(int id, UpdateEmployeeDto updateDto)
        {
            //LINQ
            //var employee = dbContext.Employees.FirstOrDefault(e => e.Employee_Id == id);


            try
            {
                var employeeDto = _employeeService.UpdateEmployee(id, updateDto);
                return Ok(employeeDto);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee(int id)
        {

         
            try
            {
                var employeeDelete = _employeeService.DeleteEmployee(id);

                return Ok(new { Message = $"Employee with id {id} deleted successfully" });

            } 
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            

        }
    }
}
        