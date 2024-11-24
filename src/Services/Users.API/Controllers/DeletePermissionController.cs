using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Users.API.UseCases.Abstractions;

namespace Users.API.Controllers;

[Tags("Permissions Management")]
[ApiController]
[Route("/permission")]
public class DeletePermissionController : ControllerBase
{
    private readonly IDeletePermissionUseCase _useCase;

    public DeletePermissionController(IDeletePermissionUseCase useCase) => _useCase = useCase;
    
    [HttpDelete("{code}")]
    public async Task<IActionResult> Perform(string code)
    {
        var result = await _useCase.Run(code);

        return StatusCode(result.StatusCode, result);
    }
}