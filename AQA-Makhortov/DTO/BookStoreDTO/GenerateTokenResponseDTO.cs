namespace AQA_Makhortov.DTO.BookStoreDTO;

public record GenerateTokenResponseDTO(
    string Token,
    string Expires,
    string Status,
    string Result);