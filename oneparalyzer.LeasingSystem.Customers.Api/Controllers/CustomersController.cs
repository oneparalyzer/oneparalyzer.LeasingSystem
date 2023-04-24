using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.RemoveById;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.FindByFullName;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;
using oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Api.Controllers;

[Route("leasing/customers")]
[ApiController]
//[Authorize(Roles = "admin")]
public class CustomersController : ControllerBase
{
    private readonly ISender _mediator;

    public CustomersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<GetAllCutomersDTO> customersDTO = await _mediator.Send(new GetAllCutomersQuery());
        return Ok(customersDTO);
    }

    [HttpPut("create")]
    public async Task<IActionResult> Create([FromBody]CreateCustomerCommand createCustomerCommand)
    {
        Result result = await _mediator.Send(createCustomerCommand);
        return Ok(result); 
    }

    [HttpDelete("{id}/remove")]
    public async Task<IActionResult> RemoveById([FromRoute]Guid id)
    {
        Result result = await _mediator.Send(new RemoveCustomerByIdCommand(id));
        return Ok(result);
    }

    [HttpGet("get-by-fullname")]
    public async Task<IActionResult> FindByFullName([FromBody]string fullName)
    {
        IEnumerable<GetAllCutomersDTO> customersDTO = await _mediator.Send(new GetCustomerByFullNameQuery(fullName));
        return Ok(customersDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id)
    {
        GetCustomerByIdDTO customerDTO = await _mediator.Send(new GetCustomerByIdQuery(id));
        return Ok(customerDTO);
    }
}
