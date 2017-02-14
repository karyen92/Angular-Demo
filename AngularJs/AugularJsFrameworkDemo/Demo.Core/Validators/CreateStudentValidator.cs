using Demo.Core.Models;
using FluentValidation;
using MongoDB.Driver;

namespace Demo.Core.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentValidator(IMongoDatabase db)
        {
            RuleFor(dto => dto.StudentId).NotNull().WithMessage("Student Id Must Be Set");
            RuleFor(dto => dto.Name).NotNull().WithMessage("Name Must Be Set.");
            RuleFor(dto => dto.RegisterClass).NotNull().WithMessage("Class Must Be Set.");
            RuleFor(dto => dto.StudentId)
                .SetValidator(new StudentIdMustNotDuplicateValidation(db));
        }
    }
}
