using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Commands.Create;

public sealed class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateFeedbackCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateFeedbackCommand command, CancellationToken cancellationToken)
    {
        var feedback = new Feedback(Guid.NewGuid(), command.UserId, command.Text);
        await _unitOfWork.FeedbacksRepository.CreateAsync(feedback, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
