using AQA_Makhortov.Interfaces.DapperTestInterfaces;
using AQA_Makhortov.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AQA_Makhortov.Modules
{
    public static class DataAccessMarketplaceModule
    {
        public static IServiceCollection AddDataAccessMarketplace(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository>(p => new UserRepository(connectionString));
            services.AddScoped<IAddressRepository>(p => new AddressRepository(connectionString));
            services.AddScoped<ICategoryRepository>(p => new CategoryRepository(connectionString));
            services.AddScoped<IProductRepository>(p => new ProductRepository(connectionString));
            services.AddScoped<IOrderRepository>(p => new OrderRepository(connectionString));
            return services;
        }
    }
}