using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    Task<List<TodoDto>> GetAllAsync();
    Task<TodoDto?> GetByIdAsync(int id);
    Task<TodoDto> CreateAsync(TodoCreateDto dto);
    Task<TodoDto?> UpdateAsync(int id, TodoUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
