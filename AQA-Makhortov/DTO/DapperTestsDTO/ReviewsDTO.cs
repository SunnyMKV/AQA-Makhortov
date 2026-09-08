namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record ReviewsDTO
    (
        long id,

        long userId,

        long productId,

        long rating,

        string comment,

        string createdAt
    );
}