namespace AQA_Makhortov.DTO.BookStoreDTO;

public record UserResponseDTO(
    string UserId,
    string Username,
    IReadOnlyList<BookDTO> Books);