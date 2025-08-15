namespace FlexiSchedule.Domain.Exceptions;
public class InvalidProfessionalDocumentException : Exception
{
    public InvalidProfessionalDocumentException(string message) : base(message)
    {

    }

    public InvalidProfessionalDocumentException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; set; }
}
