using Shared.Entities;
using Users.API.DTOs;
using Users.API.Repositories.Abstractions;
using Users.API.UseCases.Abstractions;

namespace Users.API.UseCases;

public class EditPermissionUseCase : IEditPermissionUseCase
{
    private readonly IPermissionsRepository _repository;

    public EditPermissionUseCase(IPermissionsRepository repository) => _repository = repository;
    
    public async Task<StandardResponse> Run(EditPermissionDTO dto, string code)
    {
        var result = await _repository.GetAsync("", code);
        var permission = result.FirstOrDefault();
        
        if (permission == null)
            return new StandardResponse("Permission Not Exist", "PermissionNotExistException", 404);

        permission.Name = dto.Name;
        permission.Code = dto.Code;
        permission.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(permission);

        return new StandardResponse("Updated", "OK", 200);
    }
}