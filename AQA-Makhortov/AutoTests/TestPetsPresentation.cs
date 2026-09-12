using AQA_Makhortov.Helpers;
using AQA_Makhortov.Interfaces.Pets;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AQA_Makhortov.AutoTests
{
    public class PetsRefitTests
    {
        private IPetAPI _api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
            };

            services.AddRefitClient<IPetAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://petstoreapi.com/v1");
                })
                .ConfigurePrimaryHttpMessageHandler(() => handler);

            var provider = services.BuildServiceProvider();
            _api = provider.GetRequiredService<IPetAPI>();
        }

        [Test]
        public async Task TestGet()
        {
            var result = await _api.GetAllPetsAsync();
            result.Data.Should().HaveCount(20);
        }

        [Test]
        public async Task TestGetRandomPetFromPetList()
        {
            var pets = await _api.GetAllPetsAsync();
            var randomPet = RandomizerHelper.GetRandomItem(pets.Data);
            var result = await _api.GetPetByIdAsync(randomPet.Id);
            result.Should().BeEquivalentTo(randomPet);
        }

        [Test]
        public async Task TestGetPetsByFilters()
        {
            var pets = await _api.GetAllPetsFilteredByAgeMinAndLimitedAsync(5,10);
            var result = pets.Data;
            foreach(var pet in result)
            {
                TestContext.WriteLine($"{pet}");
                pet.AgeMonths.Should().BeGreaterThanOrEqualTo(5);
            }
            var res = result.All(p => p.AgeMonths >= 5);
            res.Should().BeTrue(); 
        }
    }
}