namespace FlexiSchedule.Infrastructure.Persistence;
public class UnityOfWork : IUnitOfWork
{
    private readonly FlexiScheduleSQLServerDbContext _dbContext;

    public IProfessionalRepository Professionals { get; }

    public UnityOfWork(FlexiScheduleSQLServerDbContext dbContext)
    {
        _dbContext = dbContext;

        Professionals = new ProfessionalRepository(_dbContext);
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();
}
