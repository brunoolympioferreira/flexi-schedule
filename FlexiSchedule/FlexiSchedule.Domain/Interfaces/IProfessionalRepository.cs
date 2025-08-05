namespace FlexiSchedule.Domain.Interfaces;
public interface IProfessionalRepository
{
    void Add(Professional professional);
    void Update(Professional professional);
    void Remove(Professional professional);
    Task<Professional?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Professional>> GetAllAsync(CancellationToken cancellationToken = default);
}
