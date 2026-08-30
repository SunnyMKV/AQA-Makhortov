namespace AQA_Makhortov.DTO.UsersDataDTO;

using System.Text.Json.Serialization;

public record UsersDTO(
    [property: JsonPropertyName("data")] List<DataDTO> Data);