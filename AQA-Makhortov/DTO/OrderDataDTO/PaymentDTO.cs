using System.Text.Json.Serialization;

namespace AQA_Makhortov.DTO.OrderDataDTO;

public record PaymentDTO(
    [property: JsonPropertyName("method")] string Method,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("transactionId")] string TransactionId);