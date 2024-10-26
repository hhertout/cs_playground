using System.Text.Json.Serialization;

namespace auth_api.Domain.ValueObject;

public record CreateUserValueObj
{
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    
    [JsonPropertyName("password")]
    public string? Password { get; init; }
}