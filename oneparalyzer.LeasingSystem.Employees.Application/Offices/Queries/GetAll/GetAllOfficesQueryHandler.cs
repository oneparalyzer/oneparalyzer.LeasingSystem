

using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Queries.GetAll;

public sealed class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, ResultWithData<IEnumerable<GetAllOfficesDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllOfficesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultWithData<IEnumerable<GetAllOfficesDTO>>> Handle(GetAllOfficesQuery query, CancellationToken cancellationToken)
    {
        var result = new ResultWithData<IEnumerable<GetAllOfficesDTO>>();
        result.IsOk = true;

        ResultWithData<IEnumerable<Office>> getAllResult = await _unitOfWork
            .OfficesRepository
            .GetAllAsync(cancellationToken);

        if (!getAllResult.IsOk )
        {
            result.IsOk = false;
            result.AddRangeError(getAllResult.Errors.ToList());
            return result;
        }

        IEnumerable<Office>? offices = getAllResult.Data;

        var officesDTO = _mapper.Map<IEnumerable<GetAllOfficesDTO>>(offices);
        result.Data = officesDTO;
        return result;
    }
}
