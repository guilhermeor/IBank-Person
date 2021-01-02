using Person.Application;
using Microsoft.AspNetCore.Mvc;

namespace Person.API.Presenters
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T>(Response<T> response) where T : class;
    }
}
