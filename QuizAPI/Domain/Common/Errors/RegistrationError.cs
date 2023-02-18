using System.Net;

namespace Domain.Common.Errors
{
    public class RegistrationError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public string Title => "Failed to register user";
    }
}
