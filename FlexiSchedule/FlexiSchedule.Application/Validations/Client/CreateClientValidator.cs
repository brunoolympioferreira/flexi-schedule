namespace FlexiSchedule.Application.Validations.Client;
public class CreateClientValidator : AbstractValidator<CreateClientInputModel>
{
    public CreateClientValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Client name is required.")
            .MaximumLength(100).WithMessage("Client name must not exceed 100 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Client email is required.")
            .EmailAddress().WithMessage("Client email must be a valid email address.")
            .MaximumLength(100).WithMessage("Client email must not exceed 100 characters.");

        RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Client phone is required.")
            .MaximumLength(15).WithMessage("Client phone must not exceed 15 characters.");
    }
}
