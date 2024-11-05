using System.Text.Json.Serialization;

namespace auth_api.Domain.Dto;

public record CreateUserArgs
{
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("password")]
    public string? Password { get; init; }
}