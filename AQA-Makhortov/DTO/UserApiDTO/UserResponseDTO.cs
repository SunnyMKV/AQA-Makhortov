using System.Text.Json.Serialization;

namespace AQA_Makhortov.DTO.UserApiDTO;

public class UserResponseDTO
{
    [JsonPropertyName("data")]
    public UserDataDTO Data { get; set; }
}