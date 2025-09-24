using FlexiSchedule.CrossCutting.Models;

namespace FlexiSchedule.Application.Services.Client.ReadOnly;
public interface IClientReadOnlyService
{
    PagedResult<ClientViewModel> GetAll(Guid professionalId, int pageNumber, int pageSize);
}
