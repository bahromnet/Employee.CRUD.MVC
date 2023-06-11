using Application.MVC.Commons.Interfaces;
using Domain.MVC.Entities;
using MediatR;

namespace Application.MVC.UseCases.Employees.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public string FullName { get; set; }
    public Guid DepartmentId { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new()
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            DepartmentId = request.DepartmentId,
            Salary = request.Salary,
            HireDate = DateTime.Now
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);
        return employee.Id;
    }
}
