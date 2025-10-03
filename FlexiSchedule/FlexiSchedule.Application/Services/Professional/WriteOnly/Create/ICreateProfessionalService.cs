using FlexiSchedule.Application.Models.InputModels.Professional;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Create;
public interface ICreateProfessionalService
{
    Task CreateAsync(ProfessionalCreateInputModel inputModel, CancellationToken cancellationToken = default);
}
