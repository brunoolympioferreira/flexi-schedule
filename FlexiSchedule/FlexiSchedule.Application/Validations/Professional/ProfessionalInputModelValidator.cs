namespace FlexiSchedule.Application.Validations.Professional;
public class ProfessionalInputModelValidator : AbstractValidator<ProfessionalInputModel>
{
    public ProfessionalInputModelValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("Property Name can't be null")
            .NotEmpty().WithMessage("Property Name can't be empty");

        RuleFor(p => p.Company)
            .NotNull().WithMessage("Property Company can't be null")
            .NotEmpty().WithMessage("Property Company can't be empty");

        RuleFor(p => p.DocumentType)
            .NotNull().WithMessage("Property DocumentType can't be null")
            .NotEmpty().WithMessage("Property DocumentType can't be empty");

        RuleFor(p => p.Document)
            .NotNull().WithMessage("Property Document can't be null")
            .NotEmpty().WithMessage("Property Document can't be empty");

        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("Property e-mail should be valid");

        RuleFor(p => p.Password)
            .NotNull().WithMessage("Property Password can't be null")
            .NotEmpty().WithMessage("Property Password can't be empty");

        RuleFor(p => p.Phone)
            .NotNull().WithMessage("Property Phone can't be null")
            .NotEmpty().WithMessage("Property Phone can't be empty");
    }
}
