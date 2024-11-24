namespace Shared.Entities;

public record StandardResponse(
    string Message,
    string Code,
    int StatusCode);