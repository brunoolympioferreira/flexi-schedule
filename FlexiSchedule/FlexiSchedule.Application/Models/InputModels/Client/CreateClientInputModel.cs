namespace FlexiSchedule.Application.Models.InputModels.Client;
public record CreateClientInputModel(
    string Name, 
    string Email, 
    string Phone,
    Guid ProfessionalId, 
    ICollection<AddressDTO> Adresses
    )
{
    public Domain.Entities.Client ToEntity()
    {
        var client = new Domain.Entities.Client(Name, Email, Phone, ProfessionalId);

        return client;
    }
}
