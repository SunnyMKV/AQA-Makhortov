using System.Text.Json.Serialization;

namespace AQA_Makhortov.DTO.OrderDataDTO;

public record SummaryDTO(
    [property: JsonPropertyName("itemsTotal")] double ItemsTotal,
    [property: JsonPropertyName("deliveryFee")] double DeliveryFee,
    [property: JsonPropertyName("discount")] double Discount,
    [property: JsonPropertyName("finalTotal")] double FinalTotal);