using AQA_Makhortov.DTO.BookStoreDTO;
using AQA_Makhortov.Helpers;
using AQA_Makhortov.Interfaces.BookStore;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AQA_Makhortov.AutoTests
{
    public class BookStoreTests
    {
        private IBookStoreApi _api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookStoreApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            _api = provider.GetRequiredService<IBookStoreApi>();
        }

        /*[Test]
        public async Task TestCreateUser()
        {
            var credentials = new UserCreateRequestDTO("Sunny", "Qwerty123!");
            var result = await _api.CreateUserAsync(credentials);
            result.Username.Should().Be("Sunny");
        }*/

        [Test]
        public async Task GetUserToken()
        {
            var credentials = new UserCreateRequestDTO("Sunny", "Qwerty123!");
            var result = await _api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }
        
         [Test]
        public async Task GetUserId()
        {
            var credentials = new UserCreateRequestDTO("Sunny", "Qwerty123!");
            var result = await _api.GetUserIdAsync(credentials);
            result.UserId.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookListAsync()
        {
            var result = await _api.GetBookListAsync();
            result.Should().NotBeNull();
            result.Books.Should().HaveCount(8);
            result.Books.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookByIsbnAsync()
        {
            var result = await _api.GetBookByIsbnAsync("9781449325862");
            result.Should().NotBeNull();
        }

        [Test]
        public async Task AddBookToUserAsync() // Swagger error
        {
            var token = await GetTokenAsync();

            var listOfBooks = await _api.GetBookListAsync();
            var rndIsbn = RandomHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            var response = await _api.AddBookToUserAsync(request, token);
            response.Should().NotBeNull();
        }

        [Test]
        public async Task DeleteBookByIsbn() //Swagger error
        {
            var token = await GetTokenAsync();

            var userId = await GetUsersIdAsync();

            var request = new DeleteBookRequestDTO
            (
                "9781449331818",
                userId
            );

            var response = await _api.DeleteBookFromUserAsync(request, token);
            response.Should().NotBeNull();
        }

        [Test]
        public async Task SendInvalidRequestAsync()
        {
            var listOfBooks = await _api.GetBookListAsync();
            var rndIsbn = RandomHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO 
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            Func<Task> act = async () => await _api.AddBookToUserAsync(request, token: null); 
            act.Should().ThrowAsync<ApiException>();
        }

        [Test]
        public async Task AddBookWithInvalidIsbnAsync()
        {
            var token = await GetTokenAsync();
            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO("INVALID_ISBN") }
            );

            Func<Task> act = async () => await _api.AddBookToUserAsync(request, token);
            act.Should().ThrowAsync<ApiException>();
        }
        
        private async Task<string > GetTokenAsync()
        {
            var credentials = new UserCreateRequestDTO("Sunny", "Qwerty123!");
            var token = await _api.GenerateTokenAsync(credentials);
            var result = $"Bearer {token.Token}";
            return result;
        }

        private async Task<string> GetUsersIdAsync()
        {
            var credentials = new UserCreateRequestDTO("Sunny", "Qwerty123!");
            var result = await _api.GetUserIdAsync(credentials);
            return result.UserId;
        }
    }
}