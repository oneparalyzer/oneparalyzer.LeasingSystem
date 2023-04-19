

namespace oneparalyzer.LeasingSystem.Auth.Api.Entities;

public sealed class Role
{
    public Role(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
}
