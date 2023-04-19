using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using oneparalyzer.LeasingSystem.Auth.Api.Entities;
using oneparalyzer.LeasingSystem.Auth.Api.Services.Interfaces;
using oneparalyzer.LeasingSystem.Auth.Api.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace oneparalyzer.LeasingSystem.Auth.Api.Services.Implementations;

public class JwtTokenService : IJwtTokenService
{
    private readonly JwtSettings _authSettings;

    public JwtTokenService(IOptions<JwtSettings> authOptions)
    {
        _authSettings = authOptions.Value;
    }

    public string GenerateJwtToken(User user)
    {
        SymmetricSecurityKey securityKey = _authSettings.GetSymmetricSecurityKey();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim("role", role.Title));
        }

        var token = new JwtSecurityToken(
            issuer: _authSettings.Issuer,
            audience: _authSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddSeconds(_authSettings.TokenLifeTime),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
