namespace oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;

public class GetAllUsersResponse : GetByIdUserResponse
{
    public IEnumerable<string> RolesTitle { get; set; }
}
