

namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Requests;

public sealed class RegisterRequest
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
