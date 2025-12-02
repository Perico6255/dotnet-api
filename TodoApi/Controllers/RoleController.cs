
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet]
     
    public async Task<ActionResult<List<Role>>> GetAll()
    {
        var roles= await _roleService.GetAllAsync();
        return Ok(roles);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Role>> GetById(int id)
    {
        var role = await _roleService.GetByIdAsync(id);
        if (role is null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> Create([FromBody] Role role)
    {
        try
        {
            var created = await _roleService.CreateAsync(role);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            // Ej: usuario no existe
            return BadRequest(new { message = ex.Message });
        }
    }


}