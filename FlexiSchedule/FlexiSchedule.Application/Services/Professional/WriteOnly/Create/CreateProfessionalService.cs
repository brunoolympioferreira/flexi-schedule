using FlexiSchedule.Application.Models.InputModels.Professional;

namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Create;
public class CreateProfessionalService(IUnitOfWork unitOfWork, ProfessionalValidator validator) : ICreateProfessionalService
{
    public async Task CreateAsync(ProfessionalCreateInputModel inputModel, CancellationToken cancellationToken = default)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(inputModel.Password, BCrypt.Net.BCrypt.GenerateSalt(12));
        DocumentTypeEnum documentType = (DocumentTypeEnum)Enum.Parse(typeof(DocumentTypeEnum), inputModel.DocumentType);

        var professional = inputModel.ToEntity(passwordHash, documentType);

        await validator.ValidateUniqueAsync(professional, cancellationToken);

        unitOfWork.Professionals.Add(professional);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
