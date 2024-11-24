using Microsoft.AspNetCore.Mvc;
using Users.API.DTOs;
using Users.API.UseCases.Abstractions;

namespace Users.API.Controllers;

[Tags("Permissions Management")]
[ApiController]
[Route("/permission")]
public class GetByPagePermissionController : ControllerBase
{
    private readonly IGetByPagePermissionUseCase _useCase;

    public GetByPagePermissionController(IGetByPagePermissionUseCase useCase) => _useCase = useCase;
    
    [HttpGet]
    public async Task<IActionResult> Perform([FromQuery] GetByPagePermissionDTO.Input input)
    {
        var result = await _useCase.Run(input);

        return StatusCode(result.StatusCode, result);
    }
}