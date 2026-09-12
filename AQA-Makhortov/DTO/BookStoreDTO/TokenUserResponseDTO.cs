namespace AQA_Makhortov.DTO.BookStoreDTO;

public record TokenUserResponseDTO(
    string Token,
    string Expires,
    string Status,
    string Result);