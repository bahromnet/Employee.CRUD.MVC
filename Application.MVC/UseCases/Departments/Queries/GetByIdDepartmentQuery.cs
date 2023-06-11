using Application.MVC.Commons.Interfaces;
using Application.MVC.Commons.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Departments.Queries;

public class GetByIdDepartmentQuery : IRequest<DepartmentDto>
{
    public Guid Id { get; set; }
}

public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, DepartmentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdDepartmentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DepartmentDto> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id);
        var result = _mapper.Map<DepartmentDto>(entity);
        return result;
    }
}
