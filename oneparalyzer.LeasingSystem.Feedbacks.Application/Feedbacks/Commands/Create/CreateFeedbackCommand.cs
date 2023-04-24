using MediatR;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Commands.Create;

public record CreateFeedbackCommand(
    Guid UserId, 
    string Text) : IRequest;

