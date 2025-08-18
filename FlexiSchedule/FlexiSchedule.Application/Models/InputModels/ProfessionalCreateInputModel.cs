namespace FlexiSchedule.Application.Models.InputModels;
public record ProfessionalCreateInputModel(
    string Name,
    string Company,
    string DocumentType,
    string Document,
    string Email,
    string Password,
    string Phone)
{
    public Professional ToEntity(string passwordHash, DocumentTypeEnum documentType) => new(
        Name,
        Company,
        documentType,
        Document,
        Email,
        passwordHash,
        Phone);
}
