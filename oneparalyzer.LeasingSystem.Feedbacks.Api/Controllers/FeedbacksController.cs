using MediatR;
using Microsoft.AspNetCore.Mvc;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Commands.Create;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

namespace oneparalyzer.LeasingSystem.Feedbacks.Api.Controllers;

[Route("leasing/feedbacks")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly ISender _mediator;

    public FeedbacksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<GetAllFeedbacksDTO> feedbacksDTO = await _mediator.Send(new GetAllFeedbacksQuery());
        return Ok(feedbacksDTO);
    }

    [HttpPut("create")]
    public async Task<IActionResult> Create(CreateFeedbackCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
