using System.Net;

namespace Domain.Common.Errors
{
    public class NotExistingEmailError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string Title => "Account with such mail does not exist";
    }
}
