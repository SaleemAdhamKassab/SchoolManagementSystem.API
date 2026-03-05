using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Core.Features.Students.Commands.Validators;

public class EditStudentValidator : AbstractValidator<EditStudentCommand>
{
    private readonly IStudentService _studentService;

    public EditStudentValidator(IStudentService studentService)
    {
        _studentService = studentService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    public void ApplyValidationRules()
    {
        RuleFor(e => e.FirstName)
            .NotEmpty()
            .NotNull();

        RuleFor(e => e.LastName)
           .NotEmpty()
           .NotNull();

        RuleFor(e => e.Address)
          .NotEmpty()
          .NotNull();
    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(e => e.FirstName.Trim().ToLower() + e.LastName.Trim().ToLower())
            .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsFullNameExistExecludeSelf(key,model.Id))
            .WithMessage("Student already exist");
    }
}
