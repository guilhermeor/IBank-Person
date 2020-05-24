using ClientInfo.API.Presenters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClientInfo.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IBasePresenter _presenter;

        protected readonly int DEFAULT_PAGE_NUMBER = 1;
        protected readonly int DEFAULT_PAGE_SIZE = 10;

        public BaseController(IMediator mediator, IBasePresenter basePresenter)
        {
            _presenter = basePresenter;
            _mediator = mediator;
        }
    }
}
