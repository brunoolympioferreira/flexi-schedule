namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class ProfessionalRepository(FlexiScheduleSQLServerDbContext dbContext)
    : IProfessionalRepository
{
    public void Add(Professional professional)
    {
        dbContext.Professionals.Add(professional);
    }

    public void Update(Professional professional)
    {
        throw new NotImplementedException();
    }

    public void Remove(Professional professional)
    {
        throw new NotImplementedException();
    }

    public Task<Professional?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Professional>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
