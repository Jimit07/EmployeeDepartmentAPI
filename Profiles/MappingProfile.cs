using AutoMapper;
using EmployeeDepartmentAPI.Models.DTO;
using EmployeeDepartmentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, ShowEmployeeDto>()
           .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));
            //destination and source
            //CreateMap<Employee, ShowEmployeeDto>();

            CreateMap<Department, ShowDepartmentDto>();

            CreateMap<AddEmployeeDto, Employee>();

            CreateMap<AddDepartmentDto, Department>();

            CreateMap<UpdateEmployeeDto, Employee>();

            CreateMap<UpdateDepartmentNameDto, Department>();
        }
    }
}
