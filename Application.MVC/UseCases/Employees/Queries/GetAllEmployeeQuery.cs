using Application.MVC.Commons.Interfaces;
using Application.MVC.Commons.Models;
using AutoMapper;
using MediatR;

namespace Application.MVC.UseCases.Employees.Queries;

public class GetAllEmployeeQuery : IRequest<IQueryable<EmployeeDto>>
{
}

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IQueryable<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllEmployeeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IQueryable<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entities = _context.Employees;
        var result = _mapper.ProjectTo<EmployeeDto>(entities);

        return Task.FromResult(result);
    }

    
}
