using AQA_Makhortov.DTO.DapperTestsDTO;

namespace AQA_Makhortov.Interfaces.DapperTestInterfaces;

public interface IProductRepository
{
    Task<ProductDTO> GetProductByIdAsync(int id);
}