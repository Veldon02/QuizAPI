using System.Net;

namespace Domain.Common.Errors
{
    public class ValidationError : IError
    {
        private readonly string _propertyName;
        private readonly string _message;

        public ValidationError(string propertyName, string message)
        {
            _propertyName = propertyName;
            _message = message;
        }
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string Title => $"Property: {_propertyName}  Message: {_message}";
    }
}
