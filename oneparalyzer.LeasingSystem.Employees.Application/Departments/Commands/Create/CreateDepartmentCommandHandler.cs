using MediatR;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Departments.Commands.Create;

public sealed class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var result = new Result();
        result.IsOk = true;

        var department = new Department(
            new DepartmentId(Guid.NewGuid()),
            command.Title,
            new OfficeId(command.OfficeId));

        Result createDepartmentResult = await _unitOfWork.DepartmentsRepository.CreateAsync(
            department,
            cancellationToken);

        if (!createDepartmentResult.IsOk) 
        {
            return createDepartmentResult;
        }

        ResultWithData<Office> getOfficeResult = await _unitOfWork.OfficesRepository.GetByIdAsync(
            new OfficeId(command.OfficeId),
            cancellationToken);

        if (!getOfficeResult.IsOk)
        {
            return getOfficeResult;
        }

        Office office = getOfficeResult.Data;
        office.AddDepartmentId(department.Id);

        Result updateOfficeResult = await _unitOfWork.OfficesRepository.UpdateAsync(
            office, 
            cancellationToken);

        if (!updateOfficeResult.IsOk)
        {
            return updateOfficeResult;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
       

        return result;
    }
}
