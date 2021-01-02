using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.API.Presenters;
using Person.Application.Mediators.Person.Add;
using Person.Application.Mediators.Person.Delete;
using Person.Application.Mediators.Person.GetAll;
using Person.Application.Mediators.Person.GetById;
using Person.Application.Mediators.Person.Update;
using System;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController(ISender sender, IBasePresenter basePresenter)
            : base(sender, basePresenter){}

        [HttpGet("persons/{id}")]
        public async Task<IActionResult> GetById(Guid id) 
            => _presenter.GetActionResult(
                await _sender.Send(new PersonFullRequest(id)));

        [HttpGet("persons")]
        public async Task<IActionResult> GetAll(int? pageNumber, int? pageSize)
            => _presenter.GetActionResult(
                await _sender.Send(new PersonShortRequest(pageNumber ?? DEFAULT_PAGE_NUMBER, pageSize ?? DEFAULT_PAGE_SIZE)));

        [HttpPost("persons")]
        public async Task<IActionResult> Add([FromBody] PersonAddRequest request) => _presenter.GetActionResult(await _sender.Send(request));

        [HttpDelete("persons/{id}")]
        public async Task<IActionResult> Delete(Guid id) => _presenter.GetActionResult(await _sender.Send(new PersonDeleteRequest(id)));

        [HttpPut("persons/{id}")]
        public async Task<IActionResult> Update([FromBody] PersonUpdateRequest request, Guid id) => _presenter.GetActionResult(await _sender.Send(request.WithId(id)));
    }
}
