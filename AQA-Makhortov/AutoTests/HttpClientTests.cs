using System.Net.Http.Json;
using System.Text.Json;

using AQA_Makhortov.DTO.UserApiDTO;

namespace AQA_Makhortov.AutoTests;

public class HttpClientTests
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
    public async Task Test1_GetUserSuccessStatusCode()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        response.EnsureSuccessStatusCode();
    }
    
    [Test]
    public async Task Test2_GetUserDataById()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        string jsonGet = await response.Content.ReadAsStringAsync();
        UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
        UserDataDTO user = userResponse.Data;
    }
    
    [Test]
    public async Task Test3_PostNewUserWithNameAndJob()
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
    public async Task Test4_PutUserWithNameAndJob()
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
    public async Task Test5_DeleteUserById()
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