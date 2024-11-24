using Shared.Entities;
using Users.API.Exceptions;
using Users.API.Repositories.Abstractions;
using Users.API.UseCases.Abstractions;

namespace Users.API.UseCases;

public class DeletePermissionUseCase : IDeletePermissionUseCase
{
    private readonly IPermissionsRepository _repository;

    public DeletePermissionUseCase(IPermissionsRepository repository) => _repository = repository;

    public async Task<StandardResponse> Run(string code)
    {
        try
        {
            await _repository.DeleteAsync(code);

            return new StandardResponse("Deleted", "Deleted", 200);
        }
        catch (PermissionNotExistException e)
        {
            return new StandardResponse(e.Message, "PermissionNotExistException", 404);
        }
        catch (Exception e)
        {
            return new StandardResponse(e.Message, "InternalServerErrorException", 500);
        }
    }
}