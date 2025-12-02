
using TodoApi.Models;

namespace TodoApi.Repositories;

public interface IPermisoRepository
{
    Task<List<Permiso>> GetAllAsync();
    Task<Permiso?> GetByIdAsync(int id);
    Task<Permiso> AddAsync(Permiso permiso);
}
