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
            BaseAddress = new Uri("http://reqres.in/api/")
        };
        _client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I3a9hG7CShczDI7fbelCNX7ZtF");
    }

    [Test]
    /*public async Task Test1()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        response.EnsureSuccessStatusCode();
    }*/

    public async Task Test2()
    {
        using HttpResponseMessage response = await _client.GetAsync("users/2");
        string jsonGet = await response.Content.ReadAsStringAsync();
        UserResponseDto userResponse = JsonSerializer.Deserialize<UserResponseDto>(jsonGet);
        UserDataDto user = userResponse.Data;
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _client.Dispose();
    }
}