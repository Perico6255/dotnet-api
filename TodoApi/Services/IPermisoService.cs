
using TodoApi.Models;

namespace TodoApi.Services;

public interface IPermisoService
{
    Task<List<Permiso>> GetAllAsync();
    Task<Permiso?> GetByIdAsync(int id);
    Task<Permiso> CreateAsync(Permiso permiso);
}