
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class PermisoRepository(AppDbContext context) : IPermisoRepository
{

    private readonly AppDbContext _context = context;

    public async Task<Permiso> AddAsync(Permiso permiso)
    {
        _context.Permisos.Add(permiso);
        await _context.SaveChangesAsync();
        return permiso;
    }

    public async Task<List<Permiso>> GetAllAsync()
    {
        return await _context.Permisos
            .ToListAsync();
    }

    public async Task<Permiso?> GetByIdAsync(int id)
    {
        return await _context.Permisos
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}