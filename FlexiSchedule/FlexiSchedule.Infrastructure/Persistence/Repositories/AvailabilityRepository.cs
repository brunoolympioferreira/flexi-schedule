namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class AvailabilityRepository(FlexiScheduleSQLServerDbContext dbContext) : IAvailabilityRepository
{
    public async Task AddAsync(Availability availability, CancellationToken cancellationToken = default)
    {
        await dbContext.Availabilities.AddAsync(availability, cancellationToken);
    }

    public async Task<Availability?> GetByProfessionalIdAsync(Guid professionalId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Availabilities
            .FirstOrDefaultAsync(a => a.ProfessionalId == professionalId, cancellationToken);
    }
}
