

using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Departments.Queries.GetAllByOfficeId;

public sealed class GetAllDepartmentsByOfficeIdQueryHandler
    : IRequestHandler<GetAllDepartmentsByOfficeIdQuery,
        ResultWithData<IEnumerable<GetAllDepartmentsByOfficeIdDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDepartmentsByOfficeIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;   
        _mapper = mapper;
    }

    public async Task<ResultWithData<IEnumerable<GetAllDepartmentsByOfficeIdDTO>>> Handle(GetAllDepartmentsByOfficeIdQuery query, CancellationToken cancellationToken)
    {
        var result = new ResultWithData<IEnumerable<GetAllDepartmentsByOfficeIdDTO>>();
        result.IsOk = true;

        ResultWithData<IEnumerable<Department>> getAllDepartmentsResult = 
            await _unitOfWork.DepartmentsRepository.GetAllByOfficeIdAsync(
                new OfficeId(query.OfficeId),
                cancellationToken);

        if (!getAllDepartmentsResult.IsOk)
        {
            result.IsOk = false;
            result.AddRangeError(getAllDepartmentsResult.Errors.ToList());
            return result;
        }

        IEnumerable<Department> departments = getAllDepartmentsResult.Data;

        var departmentsDTO = _mapper.Map< IEnumerable<GetAllDepartmentsByOfficeIdDTO>>(departments);

        result.Data = departmentsDTO;
        return result;
    }
}
