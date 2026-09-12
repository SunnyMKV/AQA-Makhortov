using AQA_Makhortov.DTO.BookStoreDTO;
using AQA_Makhortov.Interfaces.BookStore;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AQA_Makhortov.AutoTests
{
    public class BookStoreTests
    {
        private IBookAPI _api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            _api = provider.GetRequiredService<IBookAPI>();
        }

        [Test]
        public async Task TestCreateUser()
        {
            var credentials = new UserCreateBodyDTO("Sunny", "Qwerty123!");
            var result = await _api.CreateUserAsync(credentials);
            result.Username.Should().Be("Sunny");
        }

        [Test]
        public async Task TestGetToken()
        {
            var credentials = new UserCreateBodyDTO("Sunny", "Qwerty123!");
            var result = await _api.GetUserTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }
    }
}