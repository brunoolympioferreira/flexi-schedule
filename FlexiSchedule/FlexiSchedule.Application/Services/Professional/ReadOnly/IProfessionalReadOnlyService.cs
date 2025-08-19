using FlexiSchedule.Application.Models.ViewModels;

namespace FlexiSchedule.Application.Services.Professional.ReadOnly;
public interface IProfessionalReadOnlyService
{
    Task<IEnumerable<ProfessionalViewModel>> GetAllAsync(CancellationToken cancellationToken = default);
}
