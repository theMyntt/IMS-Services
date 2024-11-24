using Microsoft.AspNetCore.Mvc;
using Users.API.DTOs;
using Users.API.UseCases.Abstractions;

namespace Users.API.Controllers;

[Route("/permission")]
[ApiController]
public class CreatePermissionController : ControllerBase
{
    private ICreatePermissionUseCase _useCase;

    public CreatePermissionController(ICreatePermissionUseCase useCase) => _useCase = useCase;
    
    [HttpPost]
    public async Task<IActionResult> Perform([FromBody] CreatePermissionDTO input)
    {
        var result = await _useCase.Run(input);

        return StatusCode(result.StatusCode, result);
    }
}