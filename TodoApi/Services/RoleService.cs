
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
    public async Task<Role?> GetByIdWithPermisosAsync(int id)
    {
        return await _roleRepository.GetByIdWithPermisosAsync(id);
    }
    public async Task AddPermisoAsync(int roleId, int permisoId)
    {
        var role = await _roleRepository.GetByIdAsync(roleId) ?? throw new KeyNotFoundException("User not found");
        var permiso = await _roleRepository.GetPermisoByIdAsync(permisoId) ?? throw new KeyNotFoundException("Role not found");

        // Evitar duplicados
        if (!role.Permisos.Any(p => p.Id == permisoId))
        {
            role.Permisos.Add(permiso);
            await _roleRepository.SaveChangesAsync();
        }
    }
}