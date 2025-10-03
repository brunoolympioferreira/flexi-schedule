using FlexiSchedule.Application.Models.InputModels.Professional;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Update;
public interface IUpdateProfessionalService
{
    Task UpdateAsync(ProfessionalUpdateInputModel inputModel, Guid id, CancellationToken cancellationToken);
}
