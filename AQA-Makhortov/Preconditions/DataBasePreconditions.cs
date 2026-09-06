using AQA_Makhortov.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace AQA_Makhortov.Preconditions
{
    public class DataBasePreconditions
    {
        public ServiceProvider Provider {  get; }

        public DataBasePreconditions() 
        {
            var services = new ServiceCollection();
            services.AddDataAccessMarketplace("Data Source=marketplace.db");
            Provider = services.BuildServiceProvider();
        }
    }
}