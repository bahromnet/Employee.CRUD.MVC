using MediatR;

namespace Application.MVC.UseCases.Employees.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
}
