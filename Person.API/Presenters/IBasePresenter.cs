using Microsoft.AspNetCore.Mvc;
using Person.Application;

namespace Person.API.Presenters
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T>(Response<T> response) where T : class;
    }
}
