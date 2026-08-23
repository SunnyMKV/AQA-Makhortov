using System.Net;
using AQA_Makhortov.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AQA_Makhortov
{
    public class RefitTests
    {
        private IUserApi _api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://reqres.in/api");
            });
            
            var provider = services.BuildServiceProvider();
            _api = provider.GetRequiredService<IUserApi>();
        }

        [Test]
        public async Task Test1()
        {
            var result = await _api.GetUserAsync(2);
            Assert.That(result.Data.Id,Is.EqualTo(2));
        }
        
        [Test]
        public async Task Test2()
        {
            var request = new CreateUserRequestDTO { Name  = "John", Job = "Apple" };
            var response = await _api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("John"));
            Assert.That(response.Job, Is.EqualTo("Apple"));
        }

        [Test]
        public async Task Test3()
        {
            var deleteResult=  await _api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That((int) deleteResult.StatusCode, Is.EqualTo(204));
        }
    }
}