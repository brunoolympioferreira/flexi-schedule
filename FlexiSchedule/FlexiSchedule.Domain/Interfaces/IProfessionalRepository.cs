namespace FlexiSchedule.Domain.Interfaces;
public interface IProfessionalRepository
{
    void Add(Professional professional);
    void Update(Professional professional);
    void Remove(Professional professional);
    Task<Professional?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Professional>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> GetByDocumentAsync(string document, Guid id, CancellationToken cancellationToken = default);
    Task<Professional?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> VerifyEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
