namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;

public sealed class RegisterResponse
{
    public bool IsOk { get; set; }
    public List<string> Errors { get; set; } = new();
}
