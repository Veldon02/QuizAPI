using System.Net;

namespace Domain.Common.Errors
{
    public class DuplicateUserNameError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string Title => "Username is already in use";
    }
}
