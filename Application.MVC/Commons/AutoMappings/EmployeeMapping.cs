using Application.MVC.Commons.Models;
using AutoMapper;
using Domain.MVC.Entities;

namespace Application.MVC.Commons.AutoMappings;

public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}
