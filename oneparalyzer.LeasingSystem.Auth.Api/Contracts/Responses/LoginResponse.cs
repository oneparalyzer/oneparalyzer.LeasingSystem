using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;

public sealed class LoginResponse
{
    public bool IsOk { get; set; } = true;
    public string AccessToken { get; set; }
    public List<string> Errors { get; set; } = new();
    //public ModelStateDictionary? ValidationErrors { get; set; }
}
