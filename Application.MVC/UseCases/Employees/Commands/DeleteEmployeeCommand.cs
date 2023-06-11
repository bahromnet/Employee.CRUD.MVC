using Application.MVC.Commons.Exceptions;
using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Employees.Commands;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new NotFoundException(nameof(Department), request.Id);

        _context.Employees.Remove(entity);
        return true;
    }
}
