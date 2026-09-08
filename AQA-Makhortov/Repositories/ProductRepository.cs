using AQA_Makhortov.DTO.DapperTestsDTO;
using AQA_Makhortov.Interfaces.DapperTestInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AQA_Makhortov.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly string _connection;
    public ProductRepository(string connection)
    {
        this._connection = connection;
    }
    
    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        await using var db = new SqliteConnection(_connection);
        var productById = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * from Products WHERE Id = @id ", new { id });
        return productById;
    }
}