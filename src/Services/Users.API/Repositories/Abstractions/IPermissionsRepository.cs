using Users.API.Entities;

namespace Users.API.Repositories.Abstractions;

public interface IPermissionsRepository
{
    Task CreateAsync(PermissionEntity entity);
    Task UpdateAsync(PermissionEntity entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<PermissionEntity>> GetAsync(int limit, int page);
    Task<IEnumerable<PermissionEntity>> GetAsync(string name);
}