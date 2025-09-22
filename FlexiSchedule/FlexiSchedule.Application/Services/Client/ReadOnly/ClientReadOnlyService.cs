

namespace FlexiSchedule.Application.Services.Client.ReadOnly;
public class ClientReadOnlyService(IUnitOfWork unitOfWork) : IClientReadOnlyService
{
    public IEnumerable<ClientViewModel> GetAll(Guid professionalId)
    {
        var query = unitOfWork.Clients.GetAll()
            .Where(c => c.ProfessionalId == professionalId)
            .Select(c => new ClientViewModel(
                c.Id,
                c.Name,
                c.Email,
                c.Phone,
                c.ProfessionalId,
                c.Professional != null ? c.Professional.Name : string.Empty
            ));

        var result = query.AsEnumerable();

        return result;
    }
}
