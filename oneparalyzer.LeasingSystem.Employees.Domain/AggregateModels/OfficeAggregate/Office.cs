using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;

public sealed class Office : AggregateRoot<OfficeId>
{
    private readonly List<DepartmentId> _departmentIds = new();

    public Office(OfficeId id, Address address) : base(id)
    {
        Address = address;
        AddressId = address.Id;
    }

    private Office(OfficeId id) : base(id)
    {
        
    }

    public AddressId AddressId { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyList<DepartmentId> DepartmentIds => _departmentIds.AsReadOnly();

    public Result AddDepartmentId(DepartmentId departmentId)
    {
        var result = new Result();
        result.IsOk = true;

        DepartmentId? existingDepartmentId = _departmentIds.FirstOrDefault(x => x == departmentId);
        if (existingDepartmentId is not null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделение уже существует");
            return result;
        }

        _departmentIds.Add(departmentId);
        return result;
    }

    public Result RemoveDepartmentId(DepartmentId departmentId)
    {
        var result = new Result();
        result.IsOk = true;

        DepartmentId? existingDepartmentId = _departmentIds.FirstOrDefault(x => x == departmentId);
        if (existingDepartmentId is null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделения не существует");
            return result;
        }

        _departmentIds.Remove(departmentId);
        return result;
    }
}
