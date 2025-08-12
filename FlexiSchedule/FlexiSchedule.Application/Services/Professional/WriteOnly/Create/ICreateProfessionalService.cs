namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Create;
public interface ICreateProfessionalService
{
    Task CreateAsync(ProfessionalInputModel inputModel, CancellationToken cancellationToken = default);
}
