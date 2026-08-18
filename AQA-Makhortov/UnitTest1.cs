using System.Net.Http.Json;
using System.Text.Json;

namespace AQA_Makhortov;

public class Tests
{
    private static HttpClient _client;
    
    [OneTimeSetUp]
    public void Setup()
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri("https://reqres.in/api/")
        };
        _client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I3a9hG7CShczDI7fbelCNX7ZtF");
    }

    [Test]
    public async Task Test1()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        response.EnsureSuccessStatusCode();
    }
    
    [Test]
    public async Task Test2()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        string jsonGet = await response.Content.ReadAsStringAsync();
        UserResponseDto userResponse = JsonSerializer.Deserialize<UserResponseDto>(jsonGet);
        UserDataDto user = userResponse.Data;
    }
    
    [Test]
    public async Task Test3()
    {
        CreateUserRequestDTO newUserFields = new CreateUserRequestDTO
        {
            Name = "Larry",
            Job = "Oracle"
        };
        using HttpResponseMessage response = await _client.PostAsJsonAsync("users", newUserFields);
        string jsonPost = await response.Content.ReadAsStringAsync();
        CreateUserResponseDTO newUserFieldsResponse = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
    }
    
    [Test]
    public async Task Test4()
    {
        CreateUserRequestDTO newUserFields = new CreateUserRequestDTO
        {
            Name = "Larry",
            Job = "Valve"
        };
        using HttpResponseMessage response = await _client.PutAsJsonAsync("users/2", newUserFields);
        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task Test5()
    {
        using HttpResponseMessage response = await _client.DeleteAsync("users/2");
        response.EnsureSuccessStatusCode();
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _client.Dispose();
    }
}