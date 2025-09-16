namespace FlexiSchedule.Application.Models.DTOs;
public record AddressDTO(string Street, int Number, string District, string City, 
    string State, string Country, string ZipCode, string Complement)
{
    public Address ToEntity(Guid clientId) =>
        new(Street, Number, District, City, State, Country, ZipCode, Complement, clientId);
}
