using FlexiSchedule.Domain.Validators;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Create;
public class CreateProfessionalService(IUnitOfWork unitOfWork, ProfessionalValidator validator) : ICreateProfessionalService
{
    public async Task CreateAsync(ProfessionalInputModel inputModel, CancellationToken cancellationToken = default)
    {
        string passwordHash = PasswordHasher.HashPassword(inputModel.Password);
        DocumentTypeEnum documentType = (DocumentTypeEnum)Enum.Parse(typeof(DocumentTypeEnum), inputModel.DocumentType);

        var professional = inputModel.ToEntity(passwordHash, documentType);

        await validator.ValidateUniqueAsync(professional, cancellationToken);

        unitOfWork.Professionals.Add(professional);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
