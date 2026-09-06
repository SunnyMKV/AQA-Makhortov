namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record OrderDTO
    (
        int id,

        string userId,

        string orderDate,

        int status,

        int totalPrice
    );
}