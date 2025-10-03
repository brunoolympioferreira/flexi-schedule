namespace FlexiSchedule.Application.Models.InputModels.Professional;
public record ProfessionalUpdateInputModel(
    string Company,
    string DocumentType,
    string Document,
    string Email,
    string Password,
    string Phone)
{
}
