using System.Net;

namespace Domain.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string Title => "Email is already in use";
    }
}
