using ClientInfo.API.Controllers;
using ClientInfo.API.Presenters;
using ClientInfo.Application.Mediators.Clients.Add;
using ClientInfo.Application.Mediators.Clients.Delete;
using ClientInfo.Application.Mediators.Clients.GetAll;
using ClientInfo.Application.Mediators.Clients.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(ISender sender, IBasePresenter basePresenter)
            : base(sender, basePresenter){}

        [HttpGet("clients/{id}")]
        public async Task<IActionResult> GetById(Guid id) 
            => _presenter.GetActionResult(
                await _sender.Send(new ClientFullRequest(id)));

        [HttpGet("clients")]
        public async Task<IActionResult> GetAll(int? pageNumber, int? pageSize)
            => _presenter.GetActionResult(
                await _sender.Send(new ClientShortRequest(pageNumber ?? DEFAULT_PAGE_NUMBER, pageSize ?? DEFAULT_PAGE_SIZE)));

        [HttpPost("clients")]
        public async Task<IActionResult> Add([FromBody]ClientAddRequest request)
        {
            return _presenter.GetActionResult(await _sender.Send(request));
        }

        [HttpDelete("clients/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return _presenter.GetActionResult(await _sender.Send(new ClientDeleteRequest(id)));
        }
    }
}
