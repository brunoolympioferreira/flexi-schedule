namespace FlexiSchedule.Application.Validations.Address;
public class AddressDtoValidator : AbstractValidator<AddressDTO>
{
    public AddressDtoValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(100).WithMessage("Street must not exceed 100 characters.");

        RuleFor(a => a.Number)
            .NotNull().WithMessage("Number is required.");

        RuleFor(a => a.District)
            .NotEmpty().WithMessage("District is required.")
            .MaximumLength(100).WithMessage("District must not exceed 100 characters.");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("State is required.")
            .MaximumLength(50).WithMessage("State must not exceed 50 characters.");

        RuleFor(a => a.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");

        RuleFor(a => a.ZipCode)
            .NotEmpty().WithMessage("ZipCode is required.")
            .MaximumLength(20).WithMessage("ZipCode must not exceed 20 characters.");

        RuleFor(a => a.Complement)
            .MaximumLength(100).WithMessage("Complement must not exceed 100 characters.");
    }
}
