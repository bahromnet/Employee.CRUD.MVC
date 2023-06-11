using Application.MVC.Commons.Exceptions;
using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.UseCases.Employees.Commands;

public class UpdateEmployeeCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid DepartmentId { get; set; }
    public decimal Salary { get; set; }
}

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new NotFoundException(nameof(Department), request.Id);

        entity.FullName = request.FullName;
        entity.DepartmentId = request.DepartmentId;
        entity.Salary = request.Salary;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
