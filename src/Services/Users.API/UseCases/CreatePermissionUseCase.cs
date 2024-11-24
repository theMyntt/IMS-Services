using Shared.Entities;
using Users.API.DTOs;
using Users.API.Entities;
using Users.API.Exceptions;
using Users.API.Repositories.Abstractions;
using Users.API.UseCases.Abstractions;

namespace Users.API.UseCases;

public class CreatePermissionUseCase : ICreatePermissionUseCase
{
    private readonly IPermissionsRepository _repository;

    public CreatePermissionUseCase(IPermissionsRepository repository) => _repository = repository;
    
    public async Task<StandardResponse> Run(CreatePermissionDTO input)
    {
        var entity = new PermissionEntity
        {       
            Name = input.Name.ToUpper(),
            Code = input.Code.ToUpper(),
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            await _repository.CreateAsync(entity);

            return new StandardResponse("Created.", "Created", 201);
        }
        catch (PermissionAlreadyExistException e)
        {
            return new StandardResponse(e.Message, "PermissionAlreadyExistException", 409);
        }
        catch (Exception e)
        {
            return new StandardResponse(e.Message, "InternalServerErrorException", 500);
        }
    }
}