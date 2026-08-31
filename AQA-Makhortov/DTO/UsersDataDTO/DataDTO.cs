namespace AQA_Makhortov.DTO.UsersDataDTO;

using System.Text.Json.Serialization;

public record DataDTO(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("profile")] ProfileDTO Profile,
    [property: JsonPropertyName("roles")] List<string> Roles);