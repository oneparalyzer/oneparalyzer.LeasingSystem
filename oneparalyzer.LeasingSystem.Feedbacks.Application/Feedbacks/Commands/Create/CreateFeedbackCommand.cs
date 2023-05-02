using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Commands.Create;

public record CreateFeedbackCommand(
    Guid UserId, 
    string Text) : IRequest<Result>;

