using Application.MVC.Commons.Models;
using AutoMapper;
using Domain.MVC.Entities;

namespace Application.MVC.Commons.AutoMappings;

public class DepartmentMapping : Profile
{
    public DepartmentMapping()
    {
        CreateMap<Department, DepartmentDto>().ReverseMap();
    }
}
