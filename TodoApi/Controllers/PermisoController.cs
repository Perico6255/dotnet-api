using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PermisoController(IPermisoService permisoService) : ControllerBase
{
    private readonly IPermisoService _permisoService = permisoService;

    [HttpGet]
     
    public async Task<ActionResult<List<Permiso>>> GetAll()
    {
        var permisos= await _permisoService.GetAllAsync();
        return Ok(permisos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Role>> GetById(int id)
    {
        var permiso = await _permisoService.GetByIdAsync(id);
        if (permiso is null)
            return NotFound();

        return Ok(permiso);
    }

    [HttpPost]
    public async Task<ActionResult<Permiso>> Create([FromBody] Permiso permiso)
    {
        try
        {
            var created = await _permisoService.CreateAsync(permiso);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            // Ej: usuario no existe
            return BadRequest(new { message = ex.Message });
        }
    }


}