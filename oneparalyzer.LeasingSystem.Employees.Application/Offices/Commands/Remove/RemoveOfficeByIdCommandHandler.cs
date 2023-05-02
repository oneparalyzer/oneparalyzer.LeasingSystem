using MediatR;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Remove;

public sealed class RemoveOfficeByIdCommandHandler : IRequestHandler<RemoveOfficeByIdCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOfficeByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveOfficeByIdCommand command, CancellationToken cancellationToken)
    {
        Result result = await _unitOfWork.OfficesRepository.RemoveByIdAsync(
            new OfficeId(command.OfficeId), 
            cancellationToken);
        if (result.IsOk)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        return result;
    }
}
