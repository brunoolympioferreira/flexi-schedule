namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class AvailabilityRepository(FlexiScheduleSQLServerDbContext dbContext) : IAvailabilityRepository
{
    public async Task AddAsync(Availability availability, CancellationToken cancellationToken = default)
    {
        await dbContext.Availabilities.AddAsync(availability, cancellationToken);
    }
}
