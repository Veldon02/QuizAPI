using System.Net;

namespace Domain.Common.Errors
{
    public interface IError
    {
        public HttpStatusCode StatusCode { get; }
        public string Title { get; }
    }
}
