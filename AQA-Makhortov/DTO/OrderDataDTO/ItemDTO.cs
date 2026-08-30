using System.Text.Json.Serialization;

namespace AQA_Makhortov.DTO.OrderDataDTO;

public record ItemDTO(
    [property: JsonPropertyName("productId")] int ProductId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("category")] string Category,
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("price")] double Price);