using ClientInfo.API.Controllers;
using ClientInfo.API.Presenters;
using ClientInfo.Application.Mediators.Clients.Add;
using ClientInfo.Application.Mediators.Clients.GetAll;
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
        public async Task<IActionResult> GetById(string id) 
            => _presenter.GetActionResult(
                await _mediator.Send(new ClientFullRequest(id)));

        [HttpGet("clients")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClientShort>))]
        public async Task<IActionResult> GetAll(int? pageNumber, int? pageSize)
            => _presenter.GetActionResult(
                await _mediator.Send(new ClientShortRequest(pageNumber ?? DEFAULT_PAGE_NUMBER, pageSize ?? DEFAULT_PAGE_SIZE)));

        [HttpPost("clients")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        public  OkResult Add([FromBody]ClientAddRequest request)
        {
            //_presenter.GetActionResult(
 
               _ =  _mediator.Publish(request);
            return Ok();

        }
    }
}
