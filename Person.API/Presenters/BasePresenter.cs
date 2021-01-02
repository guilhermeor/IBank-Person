using Microsoft.AspNetCore.Mvc;
using Person.Application;
using System.Net;

namespace Person.API.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public IActionResult GetActionResult<T>(Response<T> response) where T : class
            => response.Invalid() ? CreateErrorResult(response) : CreateSuccessResult(response);

        private static IActionResult CreateErrorResult<T>(Response<T> response) where T : class
        {
            var errorBody = new ApiError(response.Message, response.Errors);
            return response.StatusCode switch
            {
                HttpStatusCode.NotFound => new NotFoundObjectResult(errorBody),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(errorBody),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(errorBody),
                _ => new BadRequestObjectResult(errorBody),
            };
        }

        private static IActionResult CreateSuccessResult<T>(Response<T> response) where T : class
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(response.Result),
                HttpStatusCode.NoContent => new NoContentResult(),
                _ => new OkObjectResult(response.Result),
            };
        }
    }
}
