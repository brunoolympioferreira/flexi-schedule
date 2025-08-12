namespace FlexiSchedule.Application.Services.Professional.WriteOnly.Create;
public class CreateProfessionalService(IUnitOfWork unitOfWork) : ICreateProfessionalService
{
    public async Task CreateAsync(ProfessionalInputModel inputModel, CancellationToken cancellationToken = default)
    {
        // validar requisicao (criar um middleware de validação igual ao projeto que estou estudando)

        string passwordHash = PasswordHasher.HashPassword(inputModel.Password);
        DocumentTypeEnum documentType = (DocumentTypeEnum)Enum.Parse(typeof(DocumentTypeEnum), inputModel.DocumentType);

        var professional = inputModel.ToEntity(passwordHash, documentType);

        unitOfWork.Professionals.Add(professional);

        await unitOfWork.CommitAsync(cancellationToken);
    }
}
