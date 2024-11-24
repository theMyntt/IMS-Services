using Shared.Entities;
using Users.API.DTOs;

namespace Users.API.UseCases.Abstractions;

public interface ICreatePermissionUseCase
{
    Task<StandardResponse> Run(CreatePermissionDTO input);
}