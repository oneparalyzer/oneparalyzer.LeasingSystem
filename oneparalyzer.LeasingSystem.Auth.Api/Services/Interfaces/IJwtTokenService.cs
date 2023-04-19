using oneparalyzer.LeasingSystem.Auth.Api.Entities;

namespace oneparalyzer.LeasingSystem.Auth.Api.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateJwtToken(User user);
}
