namespace FlexiSchedule.Application.Models.InputModels.Professional;
public record ProfessionalCreateInputModel(
    string Name,
    string Company,
    string DocumentType,
    string Document,
    string Email,
    string Password,
    string Phone)
{
    public Domain.Entities.Professional ToEntity(string passwordHash, DocumentTypeEnum documentType) => new(
        Name,
        Company,
        documentType,
        Document,
        Email,
        passwordHash,
        Phone,
        []);
}
