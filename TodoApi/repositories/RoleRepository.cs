
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class RoleRepository(AppDbContext context) : IRoleRepository
{

    private readonly AppDbContext _context = context;

    public async Task<Role> AddAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role;

    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _context.Roles
            .ToListAsync();
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
    public async Task<Permiso?> GetPermisoByIdAsync(int permisoId)
    {
        return await _context.Permisos.FirstOrDefaultAsync(p => p.Id ==permisoId);
    }
    public Task<Role?> GetByIdWithPermisosAsync(int roleId)
    {
        return _context.Roles
            .Include(p => p.Permisos)
            .FirstOrDefaultAsync(r => r.Id == roleId);
    }

}