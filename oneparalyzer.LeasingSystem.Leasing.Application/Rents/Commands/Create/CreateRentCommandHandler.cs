using MediatR;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;
using oneparalyzer.LeasingSystem.Leasing.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Leasing.Application.Rents.Commands.Create;

public sealed class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, Result>
{
    private readonly IRentDbContext _context;

    public CreateRentCommandHandler(IRentDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateRentCommand command, CancellationToken cancellationToken)
    {
        var result = new Result();

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                Rent? existingRent = await _context.Rents.FirstOrDefaultAsync(x =>
                    x.ContractNumber == command.ContractNumber,
                    cancellationToken);
                if (existingRent is not null)
                {
                    result.AddError("Такой номер аренды уже существует.");
                    return result;
                }

                var rent = new Rent(
                    RentId.Create(),
                    EmployeeId.Create(command.EmployeeId),
                    ClientId.Create(command.ClientId),
                    PriceListPositionId.Create(command.PriceListPositionId),
                    command.EstimatedCompletionDate,
                    command.ContractNumber,
                    command.ContractDate);

                await _context.Rents.AddAsync(rent, cancellationToken);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                result.AddError("Произошда ошибка");
                return result;
            }
        }
    }
}
