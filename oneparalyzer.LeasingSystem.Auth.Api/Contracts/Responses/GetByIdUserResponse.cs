namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;

public class GetByIdUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}
