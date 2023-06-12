using Application.MVC.UseCases.Employees.Commands;
using FluentValidation;

namespace Application.MVC.UseCases.Employees.EmployeeValidations;

public class UpdateEmployeeCommandValidation : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Employee Id is required!");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("DepartmentId is required.");

        RuleFor(x => x.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0.");
    }
}
