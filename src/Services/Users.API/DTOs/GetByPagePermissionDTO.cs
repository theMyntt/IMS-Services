using System.ComponentModel.DataAnnotations;
using Shared.Entities;
using Users.API.Entities;

namespace Users.API.DTOs;

public static class GetByPagePermissionDTO
{
    public class Input
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Page { get; set; }
        
        [Required]
        [Range(1, 100)]
        public int Limit { get; set; }
    }

    public class Output
    {
        public required string Message { get; set; }
        public required string Code { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<PermissionEntity> Permissions { get; set; }
    }
}