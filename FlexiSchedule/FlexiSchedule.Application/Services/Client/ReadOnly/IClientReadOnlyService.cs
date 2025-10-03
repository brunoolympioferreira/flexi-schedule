using FlexiSchedule.Application.Models.DTOs.Filters;
using FlexiSchedule.CrossCutting.Models;

namespace FlexiSchedule.Application.Services.Client.ReadOnly;
public interface IClientReadOnlyService
{
    PagedResult<ClientViewModel> GetAll(Guid professionalId, int pageNumber, int pageSize, ClientFilter? filter);
    Task<ClientDetailsViewModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
