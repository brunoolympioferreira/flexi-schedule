namespace FlexiSchedule.Application.Validations.Client;
public class UpdateClientValidator : AbstractValidator<UpdateClientInputModel>
{
    public UpdateClientValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(c => !string.IsNullOrWhiteSpace(c.Email));

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone number cannot be empty.")
            .When(c => !string.IsNullOrWhiteSpace(c.Phone));

        RuleForEach(c => c.Addresses).SetValidator(new AddressDtoValidator())
            .When(c => c.Addresses.Count > 0 || c.Addresses != null);
    }
}
