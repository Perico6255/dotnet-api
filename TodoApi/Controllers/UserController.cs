
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
     
    public async Task<ActionResult<List<TodoDto>>> GetAll()
    {
        var users= await _userService.GetAllAsync();
        return Ok(users);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        try
        {
            var created = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            // Ej: usuario no existe
            return BadRequest(new { message = ex.Message });
        }
    }

}