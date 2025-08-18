namespace FlexiSchedule.Application.Models.InputModels;
public record ProfessionalUpdateInputModel(
    string Company,
    string DocumentType,
    string Document,
    string Email,
    string Password,
    string Phone)
{
}
