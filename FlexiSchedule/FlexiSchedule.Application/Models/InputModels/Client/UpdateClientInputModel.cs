namespace FlexiSchedule.Application.Models.InputModels.Client;
public record UpdateClientInputModel(string Email, string Phone, ICollection<AddressDTO> Addresses)
{
}
