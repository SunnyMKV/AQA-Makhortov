namespace AQA_Makhortov.Interfaces.DapperTestInterfaces;

public interface IOrderRepository
{
    Task<IEnumerable<dynamic>> GetOrderWithItemsAsync(int userId, int orderId);
}