namespace FlexiSchedule.Domain.Entities;
public class Client : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    //relationships
    public Guid ProfessionalId { get; private set; }
    public virtual Professional? Professional { get; set; }
    public ICollection<Address> Addresses { get; private set; } = [];

    public Client(string name, string email, string phone, Guid professionalId)
    {
        Name = name;
        Email = email;
        Phone = phone;
        ProfessionalId = professionalId;
    }

    public void Update(string email, string phone, ICollection<Address> addresses)
    {
        Email = email;
        Phone = phone;
        Addresses = addresses;
        SetUpdatedAt();
    }

    public void AddAdress(Address address)
    {
        Addresses.Add(address);
    }
}
