namespace FlexiSchedule.Domain.Entities;
public class Address : BaseEntity
{
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public string? Complement { get; private set; }

    //relationships
    public Guid ClientId { get; private set; } // Foreign key
    public Client? Client { get; set; } // Navigation property
    public Address(string street, int number, string district, string city, string state, string country, 
        string zipCode, string? complement, Guid clientId)
    {
        Street = street;
        Number = number;
        District = district;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        Complement = complement;
        ClientId = clientId;
    }
}
