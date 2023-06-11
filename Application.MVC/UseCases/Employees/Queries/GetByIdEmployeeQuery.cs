using Application.MVC.Commons.Interfaces;
using Application.MVC.Commons.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Employees.Queries;

public class GetByIdEmployeeQuery : IRequest<EmployeeDto>
{
    public Guid Id { get; set; }
}

public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdEmployeeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);
        var result = _mapper.Map<EmployeeDto>(entity);
        return result;
    }
}
