using ClientInfo.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientInfo.API.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public IActionResult GetActionResult<T>(Response<T> response) where T : class
        {
            if (response.Invalid)
                return CreateErrorResult(response);

            return new OkObjectResult(response.Data);
        }

        private IActionResult CreateErrorResult<T>(Response<T> response) where T : class
        {
            if (response.StatusCode == HttpStatusCode.OK)
                response.StatusCode = HttpStatusCode.InternalServerError;

            return response.StatusCode switch
            {
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                _ => new BadRequestObjectResult(response),
            };
        }
    }
}
