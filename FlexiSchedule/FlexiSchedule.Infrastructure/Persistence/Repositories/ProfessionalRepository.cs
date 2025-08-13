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

    public async Task<bool> GetByDocumentAsync(string document, Guid id, CancellationToken cancellationToken = default)
    {
        bool existProfessional = await dbContext.Professionals
            .AsNoTracking()
            .AnyAsync(p => p.Document.Equals(document) && p.Id != id, cancellationToken);

        return existProfessional;
    }

    public async Task<bool> GetByEmailAsync(string email, Guid id, CancellationToken cancellationToken = default)
    {
        bool existEmail = await dbContext.Professionals
            .AsNoTracking()
            .AnyAsync(p => p.Email.Equals(email) && p.Id != id, cancellationToken);

        return existEmail;
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
