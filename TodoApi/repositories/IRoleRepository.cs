using TodoApi.Models;

namespace TodoApi.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role> AddAsync(Role role);
    Task SaveChangesAsync();
    Task<Permiso?> GetPermisoByIdAsync(int permisoId);
     Task<Role?> GetByIdWithPermisosAsync(int roleId);

}
