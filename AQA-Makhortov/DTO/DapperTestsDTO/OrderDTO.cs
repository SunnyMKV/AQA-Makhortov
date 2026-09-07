namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record OrderDTO
    (
        long id,

        long userId,

        string orderDate,

        string status,

        double totalPrice
    );
}