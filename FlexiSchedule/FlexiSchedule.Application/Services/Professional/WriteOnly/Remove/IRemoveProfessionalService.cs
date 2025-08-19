namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Remove;
public interface IRemoveProfessionalService
{
    Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
}
