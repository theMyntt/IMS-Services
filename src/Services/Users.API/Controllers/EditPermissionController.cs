using Microsoft.AspNetCore.Mvc;
using Users.API.DTOs;
using Users.API.UseCases.Abstractions;

namespace Users.API.Controllers;

[ApiController]
[Route("/permission")]
public class EditPermissionController : ControllerBase
{
    private readonly IEditPermissionUseCase _useCase;

    public EditPermissionController(IEditPermissionUseCase useCase) => _useCase = useCase;
    
    [HttpPut("{code}")]
    public async Task<IActionResult> Perform(EditPermissionDTO dto, string code)
    {
        var result = await _useCase.Run(dto, code);

        return StatusCode(result.StatusCode, result);
    }    
}