namespace FlexiSchedule.Application.Models.ViewModels;
public record ProfessionalViewModel(
    Guid Id,
    string Name,
    string Company,
    string DocumentType,
    string Document,
    string Email,
    string Phone
    )
{
    public static ProfessionalViewModel FromEntity(Professional professional)
    {
        return new ProfessionalViewModel(
            professional.Id,
            professional.Name,
            professional.Company,
            professional.DocumentType.ToString(),
            professional.Document,
            professional.Email,
            professional.Phone
        );
    }
}
