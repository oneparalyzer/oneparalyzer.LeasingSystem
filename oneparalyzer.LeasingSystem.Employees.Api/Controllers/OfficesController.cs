using MediatR;
using Microsoft.AspNetCore.Mvc;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Remove;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Queries.GetAll;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Api.Controllers;

[Route("leasing/offices")]
[ApiController]
public class OfficesController : ControllerBase
{
    private readonly ISender _mediator;

    public OfficesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ResultWithData<IEnumerable<GetAllOfficesDTO>> result = await _mediator.Send(new GetAllOfficesQuery());
        return Ok(result);
    }

    [HttpPut("create")]
    public async Task<IActionResult> Create(CreateOfficeCommand command)
    {
        Result result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}/remove")]
    public async Task<IActionResult> RemoveById([FromRoute]Guid id)
    {
        Result result = await _mediator.Send(new RemoveOfficeByIdCommand(id));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        return Ok();
    }
}
