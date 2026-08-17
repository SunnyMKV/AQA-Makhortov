using System.Text.Json.Serialization;

namespace AQA_Makhortov;

public class UserResponseDto
{
    [JsonPropertyName("data")]
    public UserDataDto Data { get; set; }
}