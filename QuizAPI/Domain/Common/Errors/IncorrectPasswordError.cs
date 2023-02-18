using System.Net;

namespace Domain.Common.Errors
{
    public class IncorrectPasswordError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string Title => "Incorrect password";
    }
}
