namespace FlexiSchedule.Domain.Exceptions;
public class ProfessionalDomainException : Exception
{
    public ProfessionalDomainException(string message) : base(message)
    {

    }

    public ProfessionalDomainException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; set; }
}
