using Application.MVC.Commons.Exceptions;
using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Departments.Commands;

public class UpdateDepartmentCommand : IRequest<bool>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new NotFoundException(nameof(Department), request.Id);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
