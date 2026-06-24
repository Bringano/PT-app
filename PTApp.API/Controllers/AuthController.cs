using Microsoft.AspNetCore.Mvc;
using PTApp.Application.Services;
using PTApp.Application.Interfaces;
using PTApp.API.DTOs;

namespace PTApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ITokenService _tokenService;

    public AuthController(UserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService; 
    }

    [HttpPost("login")] 
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        try
        {
            var user = await _userService.GetUserByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized("Fel email eller lösenord");
            }

            if (user.PasswordHash != $"HASHED_{loginDto.Password}")
            {
                return Unauthorized("Fel email eller lösenord"); 
            }

            var token = _tokenService.GenerateToken(user); 

            return Ok(new { token });
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}