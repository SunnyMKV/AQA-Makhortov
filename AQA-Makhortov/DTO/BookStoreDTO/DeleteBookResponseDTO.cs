namespace AQA_Makhortov.DTO.BookStoreDTO;

public record DeleteBookResponseDTO(
    string UserId,
    string Isbn,
    string Message);