namespace FlexiSchedule.Infrastructure.Persistence.Repositories;
public class ProfessionalRepository(FlexiScheduleSQLServerDbContext dbContext)
    : IProfessionalRepository
{
    public void Add(Professional professional)
    {
        dbContext.Add(professional);
    }

    public void Update(Professional professional)
    {
        dbContext.Update(professional);
    }

    public void Remove(Professional professional)
    {
        dbContext.Remove(professional);
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

    public async Task<Professional?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Professional? professional = await dbContext.Professionals
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return professional;
    }

    public async Task<IEnumerable<Professional>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var professionals = await dbContext.Professionals
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return professionals;
    }
}
