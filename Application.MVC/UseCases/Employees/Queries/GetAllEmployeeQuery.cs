using Application.MVC.Commons.Models;
using MediatR;

namespace Application.MVC.UseCases.Employees.Queries;

public class GetAllEmployeeQuery : IRequest<IQueryable<EmployeeDto>>
{
}
