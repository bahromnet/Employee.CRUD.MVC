using Application.MVC.UseCases.Departments.Commands;
using FluentValidation;

namespace Application.MVC.UseCases.Departments.DepartmentValidations;

public class UpdateDepartmentCommandValidation : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department name is required.");

    }
}
