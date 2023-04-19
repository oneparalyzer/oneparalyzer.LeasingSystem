using MediatR;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomersDbContext _context;

    public CreateCustomerCommandHandler(ICustomersDbContext context)
    {
        _context = context;
    }

    public Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var region = 
    }
}
