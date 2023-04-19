using oneparalyzer.LeasingSystem.Auth.Api.Exceptions;

namespace oneparalyzer.LeasingSystem.Auth.Api.Entities;

public sealed class User
{
    private readonly List<Role> _roles = new();

    public User(Guid id, string email, string userName, string passwordHash)
    {
        Id = id;
        Email = email;
        UserName = userName;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public void AddRole(Role newRole)
    {
        Role? role = _roles.FirstOrDefault(x => x.Title == newRole.Title);
        if (role is not null)
        {
            throw new EntityAlreadyExistException(nameof(role));
        }

        _roles.Add(newRole);
    }
}
