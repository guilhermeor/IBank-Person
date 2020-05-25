using ClientInfo.API.Controllers;
using ClientInfo.API.Presenters;
using ClientInfo.Application.Mediators.Clients.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(IMediator mediator, IBasePresenter basePresenter)
            : base(mediator, basePresenter){}

        [HttpGet("clients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientFull>))]
        public async Task<IActionResult> GetTypes(string id) 
            => _presenter.GetActionResult(
                await _mediator.Send(new ClientFullRequest(id))
            );
    }
}
