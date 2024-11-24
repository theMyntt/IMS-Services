using System.ComponentModel.DataAnnotations;

namespace Users.API.DTOs;

public class CreatePermissionDTO
{
    [Required]
    public required string Name { get; set; }
    
    [Required]
    [MinLength(3)]
    public required string Code { get; set; }
}