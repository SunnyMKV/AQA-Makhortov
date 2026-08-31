namespace AQA_Makhortov.DTO.UsersDataDTO;

using System.Text.Json.Serialization;

public record GeoDTO(
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng);