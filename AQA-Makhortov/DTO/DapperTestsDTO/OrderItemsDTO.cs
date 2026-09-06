namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
    (
        long id,

        string orderId,

        string productId,

        long quantity,

        long unitPrice
    );
}