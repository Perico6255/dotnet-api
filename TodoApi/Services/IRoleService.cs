using TodoApi.Models;

namespace TodoApi.Services;

public interface IRoleService
{
    Task<List<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role> CreateAsync(Role role);
    Task AddPermisoAsync(int roleId, int permisoId);
    Task<Role?> GetByIdWithPermisosAsync(int id);
}