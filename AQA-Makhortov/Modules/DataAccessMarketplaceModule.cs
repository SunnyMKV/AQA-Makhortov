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
            return services;
        }
    }
}