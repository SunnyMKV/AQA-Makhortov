using AQA_Makhortov.DTO.PetsDTO;
using Refit;

namespace AQA_Makhortov.Interfaces.Pets
{
    public interface IPetAPI
    {
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsAsync();
        
        [Get("/pets/{id}")]
        Task<Pet> GetPetByIdAsync(string id);
        
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsFilteredByAgeMinAndLimitedAsync([Query] int ageMin, [Query] int limit);
    }
}