using System.Net;

using AQA_Makhortov.DTO.UserApiDTO;
using AQA_Makhortov.Interfaces.UserApiInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AQA_Makhortov.AutoTests
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
        public async Task Test1_GetUserSuccessStatusCode()
        {
            var response = await _api.GetUserStatusCodeAsync(2);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That((int) response.StatusCode, Is.EqualTo(200));
        }
        
        [Test]
        public async Task Test2_GetUserDataById()
        {
            var result = await _api.GetUserAsync(2);
            Assert.That(result.Data.Id,Is.EqualTo(2));
        }
        
        [Test]
        public async Task Test3_PostNewUserWithNameAndJob()
        {
            var request = new CreateUserRequestDTO { Name  = "John", Job = "Apple" };
            var response = await _api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("John"));
            Assert.That(response.Job, Is.EqualTo("Apple"));
        }

        [Test]
        public async Task Test4_PutUserWithNameAndJob()
        {
            var request = new CreateUserRequestDTO { Name = "John", Job = "Valve" };
            var response = await _api.PutUserAsync(2, request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That((int) response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task Test5_DeleteUserById()
        {
            var deleteResult=  await _api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Assert.That((int) deleteResult.StatusCode, Is.EqualTo(204));
        }
    }
}