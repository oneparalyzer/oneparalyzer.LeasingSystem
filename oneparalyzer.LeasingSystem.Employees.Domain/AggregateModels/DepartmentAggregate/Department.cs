using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;

public sealed class Department : AggregateRoot<DepartmentId>
{
    private readonly List<PostId> _postIds = new();

    public Department(DepartmentId id, string title, OfficeId officeId) : base(id)
    {
        Title = title;
        OfficeId = officeId;
    }

    public string Title { get; private set; }
    public OfficeId OfficeId { get; private set; }
    public IReadOnlyList<PostId> PostIds => _postIds.AsReadOnly();

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
