using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ResultWithData<GetCustomerByIdDTO>>
{
    private readonly ICustomersDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(ICustomersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResultWithData<GetCustomerByIdDTO>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = new ResultWithData<GetCustomerByIdDTO>();
        result.IsOk = true;

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

        if (customer is null)
        {
            result.IsOk = false;
            result.Errors.Add("Пользователь не найден.");
            return result;
        }

        var customerDTO = _mapper.Map<GetCustomerByIdDTO>(customer);

        result.Data = customerDTO;
        return result;
    }
}
