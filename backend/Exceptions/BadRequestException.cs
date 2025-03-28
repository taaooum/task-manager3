namespace backend.Services.Exceptions
{
    public class BadRequestException(string message) : HttpResponseException(400, message);
}
