using AQA_Makhortov.DTO.DapperTestsDTO;
using AQA_Makhortov.Interfaces.DapperTestInterfaces;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AQA_Makhortov.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                                                                        "WHERE UserId = @userId", new { userId });
            return address;
        }
    }
}