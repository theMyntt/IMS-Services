using Shared.Entities;

namespace Users.API.UseCases.Abstractions;

public interface IDeletePermissionUseCase
{
    Task<StandardResponse> Run(string code);
}