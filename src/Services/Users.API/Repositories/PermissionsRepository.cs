using Microsoft.EntityFrameworkCore;
using Users.API.Context;
using Users.API.Entities;
using Users.API.Exceptions;
using Users.API.Repositories.Abstractions;

namespace Users.API.Repositories;

public class PermissionsRepository : IPermissionsRepository
{
    private readonly DatabaseContext _context;

    public PermissionsRepository(DatabaseContext context) => _context = context;
    
    public async Task CreateAsync(PermissionEntity entity)
    {
        await _context.Permissions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PermissionEntity entity)
    {
        _context.Permissions.Attach(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var permission = await _context.Permissions.FirstOrDefaultAsync(u => u.Id == id);

        if (permission == null) throw new PermissionNotExistException();

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PermissionEntity>> GetAsync(int limit, int page)
    {
        return await _context.Permissions
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<IEnumerable<PermissionEntity>> GetAsync(string name)
    {
        return await _context.Permissions
            .Where(u => EF.Functions.Like(u.Name.ToLower(), $"{name.Trim().ToLower()}%"))
            .ToListAsync();
    }
}