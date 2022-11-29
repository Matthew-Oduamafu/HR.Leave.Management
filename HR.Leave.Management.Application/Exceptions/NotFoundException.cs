namespace HR.Leave.Management.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message, object key) : base($"{message} with value {key.ToString} was not found")
        {
        }
    }
}