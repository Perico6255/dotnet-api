
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public async Task AddRoleAsync(int userId, int roleId)
    {
        var user = await _userRepository.GetByIdAsync(userId) ?? throw new KeyNotFoundException("User not found");
        var role = await _userRepository.GetRoleByIdAsync(roleId) ?? throw new KeyNotFoundException("Role not found");

        // Evitar duplicados
        if (!user.Roles.Any(r => r.Id == roleId))
        {
            user.Roles.Add(role);
            await _userRepository.SaveChangesAsync();
        }
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }
    public async Task<User?> GetByIdWithRoleAsync(int id)
    {
        return await _userRepository.GetByIdWithRolesAsync(id);
    }

    public Task<User?> UpdateAsync(int id, UserDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> ValidateUserAsync(string email, string plainPassword)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null)
            return null;

        var isPasswordValid = user.Password == plainPassword; // SOLO DEMO
        if (!isPasswordValid)
            return null;

        return user;
    }
}