using TodoApi.Models;

namespace TodoApi.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> AddAsync(User user);
    Task<User?> GetByEmailAsync(String email);
    Task SaveChangesAsync();

    Task<Role?> GetRoleByIdAsync(int userId);
    Task<User?> GetByIdWithRolesAsync(int userId);
}
