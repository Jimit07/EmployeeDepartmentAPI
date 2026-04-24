using AutoMapper;
using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models.DTO;
using EmployeeDepartmentAPI.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _dbContext;

        private readonly IMapper _mapper;

        public DepartmentService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ShowDepartmentDto> GetDepartments()
        {
            var departments = _dbContext.Departments.Include(e=>e.Employees).ToList();
            return _mapper.Map<List<ShowDepartmentDto>>(departments);
        }


        //add department

        public ShowDepartmentDto AddDepartment(AddDepartmentDto addDepartmentdto)
        {
            var departmentEntity = _mapper.Map<Department>(addDepartmentdto);
            _dbContext.Departments.Add(departmentEntity);
            _dbContext.SaveChanges();
            return _mapper.Map<ShowDepartmentDto>(departmentEntity);
        }


         //update department
        public ShowDepartmentDto UpdateDepartment(int id ,UpdateDepartmentNameDto updateDepartmentdto)
        {

            var department = _dbContext.Departments.Find(id);
            if(department == null)
            {
               
                throw new KeyNotFoundException($"Department with ID {id} was not found.");
            }
            _mapper.Map(updateDepartmentdto, department);
            _dbContext.SaveChanges();

            return _mapper.Map<ShowDepartmentDto>(department);
        }

        //delete department
        public bool DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department ==null)
            {
                throw new KeyNotFoundException($"Department with ID {id} was not found."); // Department not found
            }
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();

            return true; //delete  successfully

        }

       
    }
}
