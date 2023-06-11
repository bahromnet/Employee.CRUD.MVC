using Application.MVC.Commons.Interfaces;
using Application.MVC.Commons.Models;
using AutoMapper;
using MediatR;

namespace Application.MVC.UseCases.Departments.Queries;

public class GetAllDepartmentQuery : IRequest<IQueryable<DepartmentDto>>
{
}

public class GetAllDepartmentQueryHAndler : IRequestHandler<GetAllDepartmentQuery, IQueryable<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllDepartmentQueryHAndler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IQueryable<DepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        var entities = _context.Departments;
        var result = _mapper.ProjectTo<DepartmentDto>(entities);

        return Task.FromResult(result);
    }
}
