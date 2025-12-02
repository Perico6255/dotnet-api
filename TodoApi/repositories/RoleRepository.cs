
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
}