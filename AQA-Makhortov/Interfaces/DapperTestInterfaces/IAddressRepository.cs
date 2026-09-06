using AQA_Makhortov.DTO.DapperTestsDTO;

namespace AQA_Makhortov.Interfaces.DapperTestInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId (int userId);
    }
}