using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public class MarkNotFoundError : IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string Title => "Passer do not have mark for this quiz";
    }
}
