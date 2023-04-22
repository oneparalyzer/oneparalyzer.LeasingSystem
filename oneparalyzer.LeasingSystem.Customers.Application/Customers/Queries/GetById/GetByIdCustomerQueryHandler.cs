using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public sealed class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCustomerDTO>
{
    private readonly ICustomersDbContext _context;
    private readonly IMapper _mapper;

    public GetByIdCustomerQueryHandler(ICustomersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetByIdCustomerDTO> Handle(GetByIdCustomerQuery query, CancellationToken cancellationToken)
    {
        Customer? customer = await _context.Customers
            .Include(x => x.Address)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Region)
            .Include(x => x.Documents)
                .ThenInclude(x => x.IssuingDepartment)
            .FirstOrDefaultAsync(x => 
                x.Id == query.CustomerId, 
                cancellationToken);

        var customerDTO = _mapper.Map<GetByIdCustomerDTO>(customer);
        return customerDTO;
    }
}
