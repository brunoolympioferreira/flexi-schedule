
using FlexiSchedule.CrossCutting.Exceptions;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Update;
public class UpdateProfessionalService(IUnitOfWork unitOfWork) : IUpdateProfessionalService
{
    public async Task UpdateAsync(ProfessionalUpdateInputModel inputModel, Guid id, CancellationToken cancellationToken)
    {
        var professional = await unitOfWork.Professionals.GetByIdAsync(id, cancellationToken) 
            ?? throw new NotFoundException(nameof(Domain.Entities.Professional), id);

        string passwordHash = PasswordHasher.HashPassword(inputModel.Password);        
        DocumentTypeEnum documentType = (DocumentTypeEnum)Enum.Parse(typeof(DocumentTypeEnum), inputModel.DocumentType);

        professional.Update(inputModel.Company, documentType, inputModel.Document, inputModel.Email, passwordHash, inputModel.Phone);

        unitOfWork.Professionals.Update(professional);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
