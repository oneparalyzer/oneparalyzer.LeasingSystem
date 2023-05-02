using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate;

public sealed class Post : AggregateRoot<PostId>
{
    private readonly List<DepartmentId> _departmentIds = new();
    private readonly List<EmployeeId> _employeeIds = new();

    public Post(PostId id, string title, DepartmentId departmentId) : base(id)
    {
        Title = title;
        _departmentIds.Add(departmentId);
    }

    private Post(PostId id) : base(id)
    {
        
    }

    public string Title { get; private set; }
    public IReadOnlyList<DepartmentId> DepartmentIds => _departmentIds.AsReadOnly();
    public IReadOnlyList<EmployeeId> EmployeeIds => _employeeIds.AsReadOnly();

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

    public Result AddEmployeeId(EmployeeId employeeId)
    {
        var result = new Result();
        result.IsOk = true;

        EmployeeId? existingEmployeeId = _employeeIds.FirstOrDefault(x => x == employeeId);
        if (existingEmployeeId is not null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделение уже существует");
            return result;
        }

        _employeeIds.Add(employeeId);
        return result;
    }

    public Result RemoveEmployeeId(EmployeeId employeeId)
    {
        var result = new Result();
        result.IsOk = true;

        EmployeeId? existingEmployeeId = _employeeIds.FirstOrDefault(x => x == employeeId);
        if (existingEmployeeId is null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделения не существует");
            return result;
        }

        _employeeIds.Remove(employeeId);
        return result;
    }
}
