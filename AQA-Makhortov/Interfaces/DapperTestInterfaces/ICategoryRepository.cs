using AQA_Makhortov.DTO.DapperTestsDTO;

namespace AQA_Makhortov.Interfaces.DapperTestInterfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
}