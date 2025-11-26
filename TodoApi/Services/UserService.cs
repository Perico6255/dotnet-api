
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


    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users;
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateAsync(int id, UserDto dto)
    {
        throw new NotImplementedException();
    }
}