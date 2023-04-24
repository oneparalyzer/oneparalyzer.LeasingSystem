using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.FindByFullName;

public sealed class GetCustomerByFullNameQueryHandler : IRequestHandler<GetCustomerByFullNameQuery, IEnumerable<GetCustomerByFullNameDTO>>
{
    private readonly ICustomersDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerByFullNameQueryHandler(ICustomersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCustomerByFullNameDTO>> Handle(GetCustomerByFullNameQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<Customer>? customers = _context.Customers.Where(x => x.FullName.ToString().ToLower().Contains(query.FullName.ToLower()));

        var customersDTO = _mapper.Map<IEnumerable<GetCustomerByFullNameDTO>>(customers);

        return customersDTO;
    }
}
