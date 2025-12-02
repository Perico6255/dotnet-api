using TodoApi.Models;

namespace TodoApi.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User?> UpdateAsync(int id, UserDto dto);
    Task<bool> DeleteAsync(int id);

    Task<User?> ValidateUserAsync(string email, string plainPassword);
}