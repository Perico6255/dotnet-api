
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<Role> CreateAsync(Role role)
    {

        return await _roleRepository.AddAsync(role);
    }
    public async Task<List<Role>> GetAllAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles;
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _roleRepository.GetByIdAsync(id);
    }
}