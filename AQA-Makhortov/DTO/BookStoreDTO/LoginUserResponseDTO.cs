namespace AQA_Makhortov.DTO.BookStoreDTO;

public record LoginUserResponseDTO(
    string UserId,
    string Username,
    string Password,
    string Token,
    string Expires,
    string Created_Date,
    bool IsActive);