namespace FlexiSchedule.CrossCutting.Exceptions;
public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string message) : base(message)
    {
        
    }

    public UnauthorizedAccessException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; set; }
}
