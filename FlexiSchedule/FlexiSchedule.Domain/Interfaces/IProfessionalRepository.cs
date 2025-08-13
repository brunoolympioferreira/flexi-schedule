namespace FlexiSchedule.Domain.Interfaces;
public interface IProfessionalRepository
{
    void Add(Professional professional);
    void Update(Professional professional);
    void Remove(Professional professional);
    Task<Professional?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Professional>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> GetByDocumentAsync(string document, Guid id, CancellationToken cancellationToken = default);
    Task<bool> GetByEmailAsync(string email,Guid id, CancellationToken cancellationToken = default);
}
