using Shared.Entities;
using Users.API.DTOs;

namespace Users.API.UseCases.Abstractions;

public interface IEditPermissionUseCase
{
    Task<StandardResponse> Run(EditPermissionDTO dto, string code);
}