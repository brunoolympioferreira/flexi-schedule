
namespace FlexiSchedule.Application.Services.Client.ReadOnly;
public class ClientReadOnlyService(IUnitOfWork unitOfWork) : IClientReadOnlyService
{
    public PagedResult<ClientViewModel> GetAll(Guid professionalId, int pageNumber, int pageSize)
    {
        var query = unitOfWork.Clients.GetAll()
            .ByProfessional(professionalId)
            .ToClientViewModel();

        var result = query.ToPagedResult(pageNumber, pageSize);

        return result;
    }

    public async Task<ClientDetailsViewModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var client = await unitOfWork.Clients.GetByIdAsync(id, cancellationToken) ?? 
            throw new NotFoundException(nameof(Domain.Entities.Client), id);

        var viewModel = client?.ToClientDetailsViewModel();

        return viewModel;
    }
}
