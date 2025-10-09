namespace FlexiSchedule.Application.Validations.Availability;
public class CreateAvailabilityValidation : AbstractValidator<CreateAvailabilityInputModel>
{
    public CreateAvailabilityValidation()
    {
        RuleFor(x => x.WeekDay)
            .NotEmpty().WithMessage("WeekDay is required.")
            .NotNull().WithMessage("WeekDay cannot be null.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("StartTime is required.")
            .NotNull().WithMessage("StartTime cannot be null.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("EndTime is required.")
            .NotNull().WithMessage("EndTime cannot be null.")
            .GreaterThan(x => x.StartTime).WithMessage("EndTime must be greater than StartTime.");

        RuleFor(x => x.DateRangeStart)
            .NotEmpty().WithMessage("DateRangeStart is required.")
            .NotNull().WithMessage("DateRangeStart cannot be null.");

        RuleFor(x => x.DateRangeEnd)
            .NotEmpty().WithMessage("DateRangeEnd is required.")
            .NotNull().WithMessage("DateRangeEnd cannot be null.")
            .GreaterThan(x => x.DateRangeStart).WithMessage("DateRangeEnd must be greater than DateRangeStart.");
    }
}
