namespace AQA_Makhortov.DTO.BookStoreDTO;

public record DeleteBookRequestDTO(
    string Isbn,
    string UserId);