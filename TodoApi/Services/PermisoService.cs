using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class PermisoService(IPermisoRepository permisoRepository) : IPermisoService
{
    private readonly IPermisoRepository _permisoRepository = permisoRepository;

    public async Task<Permiso> CreateAsync(Permiso permiso)
    {
        return await _permisoRepository.AddAsync(permiso);
    }

    public async Task<List<Permiso>> GetAllAsync()
    {
        var permisos = await _permisoRepository.GetAllAsync();
        return permisos;
    }

    public async Task<Permiso?> GetByIdAsync(int id)
    {
        return await _permisoRepository.GetByIdAsync(id);
    }
}