using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class TodoService(ITodoRepository todoRepository) : ITodoService
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<List<TodoDto>> GetAllAsync()
    {
        var todos = await _todoRepository.GetAllAsync();

        return todos.Select(t => new TodoDto(
            t.Id,
            t.Title,
            t.IsDone
        )).ToList();
    }

    public async Task<TodoDto?> GetByIdAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo is null) return null;

        return new TodoDto(
            todo.Id,
            todo.Title,
            todo.IsDone
        );
    }

    public async Task<TodoDto> CreateAsync(TodoCreateDto dto)
    {

        var todo = new Todo
        {
            Title = dto.Title,
            IsDone = dto.IsDone
        };

        var created = await _todoRepository.AddAsync(todo);

        return new TodoDto(
            created.Id,
            created.Title,
            created.IsDone
        );
    }

    public async Task<TodoDto?> UpdateAsync(int id, TodoUpdateDto dto)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo is null) return null;

        todo.Title = dto.Title;
        todo.IsDone = dto.IsDone;

        var updated = await _todoRepository.UpdateAsync(todo);
        if (updated is null) return null;

        return new TodoDto(
            updated.Id,
            updated.Title,
            updated.IsDone
        );
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _todoRepository.DeleteAsync(id);
    }
}
