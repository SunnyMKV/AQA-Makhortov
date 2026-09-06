namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record ProductDTO
    (
        long id,

        string name,

        string description,

        long price,

        long stock,

        long categoryId
    );
}