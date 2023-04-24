using MediatR;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.RemoveById;

public sealed class RemoveCustomerByIdCommandHandler : IRequestHandler<RemoveCustomerByIdCommand, Result>
{
    private readonly ICustomersDbContext _context;

    public RemoveCustomerByIdCommandHandler(ICustomersDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(RemoveCustomerByIdCommand command, CancellationToken cancellationToken)
    {
        var result = new Result();
        result.IsOk = true;

        Customer? customer = await _context.Customers.FirstOrDefaultAsync(x => 
            x.Id == command.CustomerId,
            cancellationToken);
        if (customer is null)
        {
            result.IsOk = false;
            result.Errors.Add("Клиент не найден");
            return result;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}
