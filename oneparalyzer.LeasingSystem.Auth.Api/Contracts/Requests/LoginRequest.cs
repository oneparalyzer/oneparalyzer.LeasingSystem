using System.ComponentModel.DataAnnotations;

namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Requests;

public sealed record LoginRequest
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
