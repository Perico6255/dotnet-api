using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(ITodoService todoService) : ControllerBase
{
    private readonly ITodoService _todoService = todoService;

    // GET api/todo
    [HttpGet]
    public async Task<ActionResult<List<TodoDto>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    // GET api/todo/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoDto>> GetById(int id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo is null)
            return NotFound();

        return Ok(todo);
    }

    // POST api/todo
    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create([FromBody] TodoCreateDto dto)
    {
        // [ApiController] ya se encarga de validar body nulo, etc.
        try
        {
            var created = await _todoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            // Ej: usuario no existe
            return BadRequest(new { message = ex.Message });
        }
    }

    // PUT api/todo/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<TodoDto>> Update(int id, [FromBody] TodoUpdateDto dto)
    {
        var updated = await _todoService.UpdateAsync(id, dto);
        if (updated is null)
            return NotFound();

        return Ok(updated);
    }

    // DELETE api/todo/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _todoService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
