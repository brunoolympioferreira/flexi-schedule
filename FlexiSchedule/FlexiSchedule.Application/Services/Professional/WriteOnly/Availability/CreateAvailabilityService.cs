namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Availability;
public class CreateAvailabilityService(IUnitOfWork unitOfWork) : ICreateAvailabilityService
{
    public async Task Add(Guid professionalId, CreateAvailabilityInputModel model, CancellationToken cancellationToken)
    {
        var professional = await unitOfWork.Professionals.GetByIdWithAvailabilitiesAsync(professionalId, cancellationToken) ??
            throw new NotFoundException("Professional not found.");

        var availability = await unitOfWork.Availabilities.GetByProfessionalIdAsync(professionalId, cancellationToken);

        if (!Enum.TryParse(model.WeekDay, out WeekDayEnum weekDayEnum))
            throw new ProfessionalDomainException("Invalid weekday value.");

        TimeOnly startTime = TimeOnly.FromDateTime(model.StartTime);
        TimeOnly endTime = TimeOnly.FromDateTime(model.EndTime);
        DateOnly dateRangeStart = DateOnly.FromDateTime(model.DateRangeStart);
        DateOnly dateRangeEnd = DateOnly.FromDateTime(model.DateRangeEnd);

        professional.AddAvailability(availability, weekDayEnum, startTime, endTime, dateRangeStart, dateRangeEnd, model.IsClosed);

        unitOfWork.Professionals.Update(professional);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
