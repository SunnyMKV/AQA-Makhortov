using AQA_Makhortov.DTO.BookStoreDTO;
using Refit;

namespace AQA_Makhortov.Interfaces.BookStore
{
    public interface IBookAPI
    {
        [Post("/Account/v1/User")]
        Task<UserResponseDTO> CreateUserAsync([Body] UserCreateBodyDTO credentials);
        
        [Post("/Account/v1/GenerateToken")]
        Task<TokenUserResponseDTO> GetUserTokenAsync([Body] UserCreateBodyDTO credentials);
    }
}