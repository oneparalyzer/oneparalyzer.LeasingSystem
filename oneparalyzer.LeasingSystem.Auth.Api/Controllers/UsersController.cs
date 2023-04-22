using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Auth.Api.Contracts.Responses;
using oneparalyzer.LeasingSystem.Auth.Api.Data;
using oneparalyzer.LeasingSystem.Auth.Api.Entities;

namespace oneparalyzer.LeasingSystem.Auth.Api.Controllers;

[Route("leasing/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AuthDbContext _context;
    private readonly IMapper _mapper;

    public UsersController(AuthDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<User> users = _context.Users.Include(x => x.Roles);
        var usersResponse = _mapper.Map<IEnumerable<GetAllUsersResponse>>(users);
        return Ok(usersResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        var userResponse = _mapper.Map<GetByIdUserResponse>(user);
        return Ok(userResponse);
    }
}
