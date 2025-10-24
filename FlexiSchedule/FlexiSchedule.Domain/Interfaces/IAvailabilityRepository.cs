namespace FlexiSchedule.Domain.Interfaces;
public interface IAvailabilityRepository
{
    Task AddAsync(Availability availability, CancellationToken cancellationToken = default);
    Task<Availability?> GetByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken = default);
}
