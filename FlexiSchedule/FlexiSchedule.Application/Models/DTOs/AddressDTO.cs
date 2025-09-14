namespace FlexiSchedule.Application.Models.DTOs;
public record AddressDTO(string Street, int Number, string District, string City, 
    string State, string Country, string ZipCode, string Complement, Guid ClientId)
{
    public Address ToEntity() =>
        new(Street, Number, District, City, State, Country, ZipCode, Complement, ClientId);
}
