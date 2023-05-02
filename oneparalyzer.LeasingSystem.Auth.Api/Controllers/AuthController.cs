using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Auth.Api.Constants;
using oneparalyzer.LeasingSystem.Auth.Api.Contracts.Requests;
using oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;
using oneparalyzer.LeasingSystem.Auth.Api.Data;
using oneparalyzer.LeasingSystem.Auth.Api.Entities;
using oneparalyzer.LeasingSystem.Auth.Api.Helpers;
using oneparalyzer.LeasingSystem.Auth.Api.Services.Interfaces;


namespace oneparalyzer.LeasingSystem.Auth.Api.Controllers;

[Route("leasing/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(AuthDbContext context, IJwtTokenService jwtTokenService)
    {
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
    {
        var loginResponse = new LoginResponse();

        if (!ModelState.IsValid)
        {
            loginResponse.IsOk = false;
            loginResponse.Errors.Add("Ошибка валидации");
        }

        User? user = await _context.Users.Include(x => x.Roles).FirstOrDefaultAsync(x =>
            x.Email == loginRequest.Email &&
            x.PasswordHash == HasherHelper.CreateHash(loginRequest.Password));
        if (user is null)
        {
            loginResponse.IsOk = false;
            loginResponse.Errors.Add("Не верный Email или пароль.");
            return Ok(loginResponse);
        }

        loginResponse.IsOk = true;
        loginResponse.AccessToken = _jwtTokenService.GenerateJwtToken(user);
        return Ok(loginResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequest registerRequest)
    {
        var registerResponse = new RegisterResponse();
        registerResponse.IsOk = true;

        User? user = await _context.Users.FirstOrDefaultAsync(x =>
            x.Email == registerRequest.Email);
        if (user is not null)
        {
            registerResponse.IsOk = false;
            registerResponse.Errors.Add("Такой Email уже существует");
        }

        user = await _context.Users.FirstOrDefaultAsync(x =>
            x.UserName == registerRequest.UserName);
        if (user is not null)
        {
            registerResponse.IsOk = false;
            registerResponse.Errors.Add("Такое имя пользователя уже существует");
        }

        if (!registerResponse.IsOk)
        {
            return Ok(registerResponse);
        }

        user = new User(
            Guid.NewGuid(),
            registerRequest.Email,
            registerRequest.UserName,
            HasherHelper.CreateHash(registerRequest.Password));

        Role? role = await _context.Roles.FirstOrDefaultAsync(x => x.Title == RoleConstants.User);
        if (role is null)
        {
            role = new Role(Guid.NewGuid(), RoleConstants.User);
        }

        user.AddRole(role);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        registerResponse.IsOk = true;
        return Ok(registerResponse);
    }
}
