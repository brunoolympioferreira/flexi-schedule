namespace FlexiSchedule.CrossCutting.Exceptions;
public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string message) : base(message)
    {

    }

    public AlreadyExistsException(string name, object key) : base($"Entity \"{name}\" ({key}) was already integrated.")
    {
        
    }
}
