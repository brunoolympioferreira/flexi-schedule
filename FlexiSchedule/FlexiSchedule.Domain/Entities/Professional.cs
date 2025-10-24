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
    public ICollection<Availability> Availabilities { get; set; } = [];

    private Availability _availability;


    // EF Core
    protected Professional() { }
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

    public void AddAvailability(
        Availability availability,
        WeekDayEnum weekDay,
        TimeOnly startTime,
        TimeOnly endTime, 
        DateOnly dateRangeStart, 
        DateOnly dateRangeEnd,
        bool isClosed
        )
    {
        if (dateRangeEnd < dateRangeStart)
            throw new ProfessionalDomainException("The end date must be greater than or equal to the start date.");
        else
        {
            //Verifica se o dia já está marcado como fechado dentro do mesmo intervalo
            bool dayIsClosed = Availabilities.Any(a =>
                a.WeekDay == weekDay &&
                a.IsClosed &&
                !(dateRangeEnd < a.DateRangeStart || dateRangeStart > a.DateRangeEnd));

            if (dayIsClosed)
                throw new ProfessionalDomainException($"The day {weekDay} is closed and cant't receives open times");
        }

        if (Availabilities.Count > 0 && isClosed == false)
        {
            _availability = Availability.Update(
                availability,
                weekDay,
                startTime,
                endTime,
                dateRangeStart,
                dateRangeEnd,
                isClosed
            );
        }
        else
        {
            _availability = Availability.Add(
                weekDay,
                startTime,
                endTime,
                dateRangeStart,
                dateRangeEnd,
                isClosed,
                Id);
        }

        Availabilities.Add(_availability);
    }
}
