using System.ComponentModel.DataAnnotations;

namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Requests;

public sealed class LoginRequest
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
