using Users.API.Entities;

namespace Users.API.Repositories.Abstractions;

public interface IPermissionsRepository
{
    Task CreateAsync(PermissionEntity entity);
    Task UpdateAsync(PermissionEntity entity);
    Task DeleteAsync(string code);
    Task<IEnumerable<PermissionEntity>> GetAsync(int limit, int page);
    Task<IEnumerable<PermissionEntity>> GetAsync(string name, string? code);
}