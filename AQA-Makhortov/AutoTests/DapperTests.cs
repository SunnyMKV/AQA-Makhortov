using AQA_Makhortov.Helpers;
using AQA_Makhortov.Interfaces.DapperTestInterfaces;
using AQA_Makhortov.Preconditions;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace AQA_Makhortov.AutoTests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }
        
        [Test]
        public async Task Test005CheckAllCategoriesCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoriesAsync();
            categories.Should().HaveCount(6);
        }
        
        [Test]
        public async Task Test006GetProductById()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductByIdAsync(1);
            product.name.Should().Be("iPhone 15");
            product.price.Should().Be(79990);
            product.stock.Should().Be(15);
            product.categoryId.Should().Be(1);
        }
       
        [Test]
        public async Task Test007GetOrderWithItems()
        {
            var repo = p.Provider.GetService<IOrderRepository>();
            var items = await repo.GetOrderWithItemsAsync(1, 1);
            items.Should().HaveCount(2);
            items.Any(x => x.ProductName == "iPhone 15").Should().BeTrue();
            items.Any(x => x.ProductName == "Anker PowerBank").Should().BeTrue();
        }
        
        /*[Test] //генерация базы - раскомментить, а потом запустить тест разово
        public async Task InitialiseTest()
        {
            var connectionString = "Data Source=marketplace.db";
            await using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            await DatabaseInitializer.InitializeAsync(connection);
        }*/
    }
}