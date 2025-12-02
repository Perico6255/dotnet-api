
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
    [HttpGet("withpermisos/{id:int}")]
    public async Task<ActionResult<TodoDto>> GetByIdWithRoles(int id)
    {
        var user = await _roleService.GetByIdWithPermisosAsync(id);
        if (user is null)
            return NotFound();

        return Ok(user);
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
    [HttpPost("{roleId:int}/{permisoId:int}")]
    public async Task<Role?> AddRole(int roleId, int permisoId)
    {
        await _roleService.AddPermisoAsync(roleId,permisoId);
        return await _roleService.GetByIdAsync(roleId) ;
    }


}