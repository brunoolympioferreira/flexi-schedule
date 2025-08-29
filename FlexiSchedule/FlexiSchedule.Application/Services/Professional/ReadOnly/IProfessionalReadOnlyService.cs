namespace FlexiSchedule.Application.Services.Professional.ReadOnly;
public interface IProfessionalReadOnlyService
{
    Task<IEnumerable<ProfessionalViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
    bool VerifyPassword(string password, string passwordHash);
}
