using Application.MVC.UseCases.Departments.Commands;
using FluentValidation;

namespace Application.MVC.UseCases.Departments.DepartmentValidations;

public class CreateDepartmentCommandValidation : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department name is required.");

    }
}
