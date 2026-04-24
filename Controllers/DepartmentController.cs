using AutoMapper;
using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models.DTO;
using EmployeeDepartmentAPI.Models.Entities;
using EmployeeDepartmentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }



        [HttpGet]
        public IActionResult GetDepartments()
        {

            var departmentDtos = _departmentService.GetDepartments();
            return Ok(departmentDtos);
        }



        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto addDepartmentDto)
        {
            var departmentDto = _departmentService.AddDepartment(addDepartmentDto);

            return Ok(departmentDto);

        }


        [HttpPut("updateDepartment/{id}")]

        public IActionResult UpdateDepartment(int id, [FromBody] UpdateDepartmentNameDto updateDepartmentNameDto)
        {
          

            try
            {
                // Call the service method, which can throw a KeyNotFoundException.
                var departmentDto = _departmentService.UpdateDepartment(id, updateDepartmentNameDto);

                // If successful, return a 200 OK.
                return Ok(departmentDto);
            }
            catch (KeyNotFoundException ex)
            {
                // Catch the specific exception and return a 404 Not Found response.
                return NotFound(ex.Message);
            }


        }

        [HttpDelete("{id}")]

        public IActionResult DeleteDepartment(int id)
        {
            
            try
            {
                var isDeleted = _departmentService.DeleteDepartment(id);

                return Ok(new { Message = $"Department id {id} deleted successfully" });
            } catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


        }



    }
}
