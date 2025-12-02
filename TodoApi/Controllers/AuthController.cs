using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IUserService userService, IJwtTokenService jwtTokenService)
    {
        _userService = userService;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto request)
    {
        var user = await _userService.ValidateUserAsync(request.Email, request.Password);

        if (user is null)
            return Unauthorized("Credenciales inválidas");

        // a partir de tu modelo User / UserRole / Role
        var roles = user.Roles
            .Select(ur => ur.Name)   // adapta al nombre real de la propiedad (Name, Nombre, etc.)
            .ToList();

        var token = _jwtTokenService.GenerateToken(user.Id, user.Email, roles);

        return Ok(new
        {
            accessToken = token
        });
    }
}
