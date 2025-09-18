namespace FlexiSchedule.Application.Models.ViewModels;
public record ClientViewModel(
    Guid Id, 
    string Name, 
    string Email, 
    string Phone, 
    Guid ProfessionalId, 
    string ProfessionalName
    )
{
}
