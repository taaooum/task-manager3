namespace backend.Services.Exceptions
{
    public class ArgumentNullException : Exception
    {
        protected ArgumentNullException(string message)
            : base(message)
        {
        }
    }
}