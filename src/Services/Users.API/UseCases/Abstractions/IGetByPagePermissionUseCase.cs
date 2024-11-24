using Users.API.DTOs;

namespace Users.API.UseCases.Abstractions;

public interface IGetByPagePermissionUseCase
{
    Task<GetByPagePermissionDTO.Output> Run(GetByPagePermissionDTO.Input input);
}