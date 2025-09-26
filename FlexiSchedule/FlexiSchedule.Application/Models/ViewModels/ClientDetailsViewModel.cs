namespace FlexiSchedule.Application.Models.ViewModels;
public record ClientDetailsViewModel(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    Guid ProfessionalId,
    string ProfessionalName,
    IEnumerable<AddressDTO> Addresses
)
{
}
