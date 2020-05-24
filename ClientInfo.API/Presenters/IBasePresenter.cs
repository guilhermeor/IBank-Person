using ClientInfo.Application;
using Microsoft.AspNetCore.Mvc;

namespace ClientInfo.API.Presenters
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T>(Response<T> response) where T : class;
    }
}
