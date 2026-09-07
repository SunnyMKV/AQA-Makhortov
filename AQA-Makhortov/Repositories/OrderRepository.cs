using AQA_Makhortov.DTO.DapperTestsDTO;
using AQA_Makhortov.Interfaces.DapperTestInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AQA_Makhortov.Repositories;

public class OrderRepository  : IOrderRepository
{
    private readonly string _connection;
    public OrderRepository(string connection)
    {
        this._connection = connection;
    }
    
    public async Task<IEnumerable<dynamic>> GetOrderWithItemsAsync(int userId, int orderId)
    {
        await using var db = new SqliteConnection(_connection);
        var orderWithItems = await db.QueryAsync("SELECT " + 
                                                 "o.Id as OrderId, o.UserId as UserId, o.OrderDate as OrderDate, o.Status as Status, o.TotalPrice as TotalPrice, " +
                                                 "p.Id as ProductId, p.Name as ProductName,oi.Quantity as Quantity, oi.UnitPrice as UnitPrice " +
                                                 "FROM Orders o " +
                                                 "JOIN OrderItems oi ON oi.OrderId = o.Id " +
                                                 "JOIN Products p ON p.Id = oi.ProductId " +
                                                 "WHERE o.UserId = @userId AND o.Id = @orderId", new { userId, orderId }); 
        return orderWithItems;
    }
}