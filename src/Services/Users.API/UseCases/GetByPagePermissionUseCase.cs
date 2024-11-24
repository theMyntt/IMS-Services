using Users.API.DTOs;
using Users.API.Repositories.Abstractions;
using Users.API.UseCases.Abstractions;

namespace Users.API.UseCases;

public class GetByPagePermissionUseCase : IGetByPagePermissionUseCase
{
    private readonly IPermissionsRepository _repository;

    public GetByPagePermissionUseCase(IPermissionsRepository repository) => _repository = repository;
    
    public async Task<GetByPagePermissionDTO.Output> Run(GetByPagePermissionDTO.Input input)
    {
        var result = await _repository.GetAsync(input.Limit, input.Page);

        return new GetByPagePermissionDTO.Output
        {
            Message = "Permissions found",
            Code = "PermissionsFound",
            StatusCode = 200,
            Permissions = result
        };
    }
}