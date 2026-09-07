namespace AQA_Makhortov.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
    (
        long id,

        long orderId,

        long productId,

        long quantity,

        double unitPrice
    );
}