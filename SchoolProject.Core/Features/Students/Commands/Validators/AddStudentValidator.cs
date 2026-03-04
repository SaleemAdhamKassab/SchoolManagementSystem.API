using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidator(IStudentService studentService)
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

            RuleFor(e => e.Phone)
               .NotEmpty()
               .NotNull();

            RuleFor(e => e.DepartmentId)
               .NotEmpty()
               .NotNull();
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(e => e.FirstName.Trim().ToLower() + e.LastName.Trim().ToLower())
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsFullNameExist(key))
                .WithMessage("Student already exist");
        }
    }
}