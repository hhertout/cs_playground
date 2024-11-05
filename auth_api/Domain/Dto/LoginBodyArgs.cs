using System.Text.Json.Serialization;

namespace auth_api.Domain.Dto;

public record LoginBodyArgs
{
    [JsonPropertyName("username")] public string? Username { get; init; }

    [JsonPropertyName("password")] public string? Password { get; init; }
};