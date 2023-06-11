using Application.MVC.Commons.Exceptions;
using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Departments.Commands;

public class DeleteDepartmentCommant : IRequest<bool>
{
    public Guid Id { get; init; }
}

public class DeleteDepartmentCommantCommand : IRequestHandler<DeleteDepartmentCommant, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteDepartmentCommantCommand(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteDepartmentCommant request, CancellationToken cancellationToken)
    {
        var entity = await _context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new NotFoundException(nameof(Department), request.Id);

        _context.Departments.Remove(entity);
        return true;
    }
}
