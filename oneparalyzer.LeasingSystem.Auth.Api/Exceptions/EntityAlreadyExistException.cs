namespace oneparalyzer.LeasingSystem.Auth.Api.Exceptions;

public class EntityAlreadyExistException : Exception
{
    public EntityAlreadyExistException(string message) : base(message)
    {
        
    }
}
