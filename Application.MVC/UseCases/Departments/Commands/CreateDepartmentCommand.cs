using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;

namespace Application.MVC.UseCases.Departments.Commands;

public class CreateDepartmentCommand : IRequest<Guid>
{
    public string Name { get; init; }
}

public class CreateDepartmentCommandHandle : IRequestHandler<CreateDepartmentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandle(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreationDate = DateTime.Now
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync(cancellationToken);
        return department.Id;
    }
}
