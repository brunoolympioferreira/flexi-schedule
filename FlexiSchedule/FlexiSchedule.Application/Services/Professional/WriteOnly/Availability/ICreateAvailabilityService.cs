namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Availability;
public interface ICreateAvailabilityService
{
    Task Add(Guid professionalId, CreateAvailabilityInputModel model, CancellationToken cancellationToken);
}
