namespace FlexiSchedule.Domain.Interfaces;
public interface IAvailabilityRepository
{
    Task AddAsync(Availability availability, CancellationToken cancellationToken = default);
}
