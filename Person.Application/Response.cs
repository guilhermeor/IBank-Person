using Person.Application.Extensions;
using System.Net;

namespace Person.Application
{
    public class Response<T> : ApiError where T : class
    {
        public Response(HttpStatusCode statusCode) => StatusCode = statusCode;
        public Response(T result)
        {
            Result = result;
            StatusCode = HttpStatusCode.OK;
        }

        public bool Invalid() => !StatusCode.IsSuccess();
        public T Result { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
