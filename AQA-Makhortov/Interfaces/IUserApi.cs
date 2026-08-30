using AQA_Makhortov.DTO.UserApiDTO;
using Refit;

namespace AQA_Makhortov.Interfaces
{
    [Headers("x-api-key: free_user_3I3a9hG7CShczDI7fbelCNX7ZtF")]
    public interface IUserApi
    {
        [Get ("/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);
        
        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}
