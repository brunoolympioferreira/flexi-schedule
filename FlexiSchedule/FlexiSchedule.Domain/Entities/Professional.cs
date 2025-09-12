namespace FlexiSchedule.Domain.Entities;
public class Professional : BaseEntity
{
    public string Name { get; private set; }
    public string Company { get; private set; }
    public DocumentTypeEnum DocumentType { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Phone { get; private set; }
    public IEnumerable<RefreshToken> RefreshTokens { get; private set; }

    public ICollection<Client> Clients { get; set; } = [];


    // EF Core
    public Professional()
    {
        
    }
    public Professional(string name, string company, DocumentTypeEnum documentType, string document, string email, string passwordHash, string phone, IEnumerable<RefreshToken> refreshTokens)
    {
        Name = name;
        Company = company;
        DocumentType = documentType;
        Document = document;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
        RefreshTokens = refreshTokens;
    }

    public void Update(string company, DocumentTypeEnum documentType, string document, string email, string passwordHash, string phone)
    {
        Company = company;
        DocumentType = documentType;
        Document = document;
        Email = email;
        PasswordHash = passwordHash;
        Phone = phone;
        SetUpdatedAt();
    }
}
