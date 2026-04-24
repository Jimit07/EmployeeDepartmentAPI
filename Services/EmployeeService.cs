using AutoMapper;
using EmployeeDepartmentAPI.Data;
using EmployeeDepartmentAPI.Models.DTO;
using EmployeeDepartmentAPI.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly AppDbContext _dbContext ;

        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        //show all employee
        public List<ShowEmployeeDto> GetAllEmployee()
        {
            var employee = _dbContext.Employees.Include(e => e.Department).ToList();
            return _mapper.Map<List<ShowEmployeeDto>>(employee);
            
        }
         //add employee
        public ShowEmployeeDto AddEmployee(AddEmployeeDto addEmployeedto)
        {
            var employeeEntity = _mapper.Map<Employee>(addEmployeedto);

            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();

            var createdEmployee = _dbContext.Employees.Include(e => e.Department)
                                  .FirstOrDefault(e => e.Employee_Id == employeeEntity.Employee_Id);

            return _mapper.Map<ShowEmployeeDto>(createdEmployee);

            
        }

        //update employee
        public ShowEmployeeDto UpdateEmployee(int id, UpdateEmployeeDto updateEmployeedto)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Employee_Id == id);
            if(employee == null)
            {
                throw new  KeyNotFoundException($"Employee with ID {id} was not found"); // Employee not found
            }

            _mapper.Map(updateEmployeedto, employee);

            _dbContext.SaveChanges();

          
            return _mapper.Map<ShowEmployeeDto>(employee);
        }

        //delete employee
        public  bool DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee== null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} was not found"); // Employee not found
            }
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
