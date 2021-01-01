using ClientInfo.API.Presenters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClientInfo.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ISender _sender;
        protected readonly IBasePresenter _presenter;

        protected readonly int DEFAULT_PAGE_NUMBER = 0;
        protected readonly int DEFAULT_PAGE_SIZE = 10;

        public BaseController(ISender sender, IBasePresenter basePresenter)
        {
            _presenter = basePresenter;
            _sender = sender;
        }
    }
}
