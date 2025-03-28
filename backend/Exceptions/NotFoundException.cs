namespace backend.Services.Exceptions
{
    public class NotFoundException(string message) : HttpResponseException(404, message)
    {
        
    }
}