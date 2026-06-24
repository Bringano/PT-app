using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTApp.API.DTO;
using PTApp.Application.Services;

namespace PTApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        try
        {
            var user = await _userService.RegisterUserAsync(dto.FirstName, dto.LastName, dto.Email, dto.Password); 
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
