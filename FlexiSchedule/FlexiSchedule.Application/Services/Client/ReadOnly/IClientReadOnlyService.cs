namespace FlexiSchedule.Application.Services.Client.ReadOnly;
public interface IClientReadOnlyService
{
    IEnumerable<ClientViewModel> GetAll(Guid professionalId);
}
