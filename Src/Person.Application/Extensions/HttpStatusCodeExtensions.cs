using System.Net;

namespace Person.Application.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static bool IsSuccess(this HttpStatusCode statusCode) => ((int)statusCode).IsSuccess();
        public static bool IsSuccess(this int statusCode) => (statusCode >= 200 && statusCode <= 299);
    }
}
