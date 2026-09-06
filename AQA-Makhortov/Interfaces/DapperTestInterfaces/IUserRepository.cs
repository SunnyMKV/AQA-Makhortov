using AQA_Makhortov.DTO.DapperTestsDTO;

namespace AQA_Makhortov.Interfaces.DapperTestInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName);
    }
}