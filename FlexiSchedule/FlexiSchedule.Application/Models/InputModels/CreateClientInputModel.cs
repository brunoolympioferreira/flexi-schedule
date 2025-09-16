namespace FlexiSchedule.Application.Models.InputModels;
public record CreateClientInputModel(
    string Name, 
    string Email, 
    string Phone, 
    Guid ProfessionalId, 
    ICollection<AddressDTO> Adresses
    )
{
    public Client ToEntity()
    {
        var client = new Client(Name, Email, Phone, ProfessionalId);

        return client;
    }
}
