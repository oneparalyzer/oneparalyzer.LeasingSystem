using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.EmployeeAggregate;

public sealed class Employee : AggregateRoot<EmployeeId>
{
    private readonly List<PostId> _postIds = new();

    public Employee(EmployeeId id, string serviceNumber, PostId postId) : base(id)
    {
        ServiceNumber = serviceNumber;
        DateEmployment = DateTime.Now;
        _postIds.Add(postId);
    }

    private Employee(EmployeeId employeeId) : base(employeeId) { }

    public string ServiceNumber { get; private set; }
    public DateTime DateEmployment { get; private set; }
    public DateTime? DateDismissal { get; private set; }
    public Guid? UserId { get; private set; }
    public IReadOnlyList<PostId> PostIds => _postIds.AsReadOnly();


    public void Dismiss()
    {
        DateDismissal = DateTime.Now;
    }

    public bool IsDismissed()
    {
        return DateDismissal is null;
    }

    public void BindUser(Guid userId)
    {
        UserId = userId;
    }

    public Result AddPostId(PostId postId)
    {
        var result = new Result();
        result.IsOk = true;

        PostId? existingPostId = _postIds.FirstOrDefault(x => x == postId);
        if (existingPostId is not null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделение уже существует");
            return result;
        }

        _postIds.Add(postId);
        return result;
    }

    public Result RemovePostId(PostId postId)
    {
        var result = new Result();
        result.IsOk = true;

        PostId? existingPostId = _postIds.FirstOrDefault(x => x == postId);
        if (existingPostId is null)
        {
            result.IsOk = false;
            result.AddError("Такое подразделения не существует");
            return result;
        }

        _postIds.Remove(postId);
        return result;
    }
}
