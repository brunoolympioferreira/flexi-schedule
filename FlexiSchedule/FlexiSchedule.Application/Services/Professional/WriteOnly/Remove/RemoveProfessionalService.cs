
using FlexiSchedule.CrossCutting.Exceptions;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Remove;
public class RemoveProfessionalService(IUnitOfWork unitOfWork) : IRemoveProfessionalService
{
    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var professional = await unitOfWork.Professionals.GetByIdAsync(id, cancellationToken) 
            ?? throw new NotFoundException(nameof(Domain.Entities.Professional), id);

        unitOfWork.Professionals.Remove(professional);

        await unitOfWork.CommitAsync(cancellationToken);

        return true;
    }
}
