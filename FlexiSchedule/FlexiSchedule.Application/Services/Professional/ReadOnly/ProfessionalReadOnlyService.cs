namespace FlexiSchedule.Application.Services.Professional.ReadOnly;
public class ProfessionalReadOnlyService(IUnitOfWork unitOfWork) : IProfessionalReadOnlyService
{
    public async Task<IEnumerable<ProfessionalViewModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var professionals = await unitOfWork.Professionals.GetAllAsync(cancellationToken);

        var viewModels = professionals.Select(ProfessionalViewModel.FromEntity);

        return viewModels;
    }
}
