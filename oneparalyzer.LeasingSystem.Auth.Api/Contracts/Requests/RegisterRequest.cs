

using System.ComponentModel.DataAnnotations;

namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Requests;

public sealed class RegisterRequest
{
    [MinLength(5)]
    [MaxLength(30)]
    public string UserName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [MinLength(5)]
    [MaxLength(30)]
    public string Password { get; set; } = null!;
}
