using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Commands.Create;

public sealed class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeedbackCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateFeedbackCommand command, CancellationToken cancellationToken)
    {
        var result = new Result();
        result.IsOk = true;

        var feedback = new Feedback(Guid.NewGuid(), command.UserId, command.Text);
        await _unitOfWork.FeedbacksRepository.CreateAsync(feedback, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }
}
