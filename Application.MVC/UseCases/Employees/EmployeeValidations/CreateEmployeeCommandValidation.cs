using Application.MVC.UseCases.Employees.Commands;
using FluentValidation;

namespace Application.MVC.UseCases.Employees.EmployeeValidations;

public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("DepartmentId is required.");

        RuleFor(x => x.Salary)
            .GreaterThan(0).WithMessage("Salary must be greater than 0.");

        RuleFor(x => x.HireDate)
            .NotEmpty().WithMessage("Hire date is required.")
            .Must(BeValidDate).WithMessage("Invalid hire date.");
    }

    private bool BeValidDate(DateTime date)
    {
        return date <= DateTime.Now;
    }
}
