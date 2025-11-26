
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepository(AppDbContext context) : ITodoRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<Todo>> GetAllAsync()
    {
        // Incluye el User por si lo necesitas
        return await _context.Todos
            .ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _context.Todos
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo?> UpdateAsync(Todo todo)
    {
        var exists = await _context.Todos.AnyAsync(t => t.Id == todo.Id);
        if (!exists) return null;

        _context.Todos.Update(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo is null) return false;

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}