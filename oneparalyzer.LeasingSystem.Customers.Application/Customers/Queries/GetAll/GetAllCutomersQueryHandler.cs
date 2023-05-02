using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;

public sealed class GetAllCutomersQueryHandler : IRequestHandler<GetAllCutomersQuery, ResultWithData<IEnumerable<GetAllCutomersDTO>>>
{
    private readonly ICustomersDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCutomersQueryHandler(ICustomersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResultWithData<IEnumerable<GetAllCutomersDTO>>> Handle(GetAllCutomersQuery request, CancellationToken cancellationToken)
    {
        var result = new ResultWithData<IEnumerable<GetAllCutomersDTO>>();
        result.IsOk = true;

        IEnumerable<Customer> customers = _context.Customers;

        var customersDTO = _mapper.Map<IEnumerable<GetAllCutomersDTO>>(customers);

        result.Data = customersDTO;
        return result;
    }
}
