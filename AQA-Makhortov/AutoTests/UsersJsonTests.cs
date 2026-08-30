using System.Text.Json;
using AQA_Makhortov.DTO.UsersDataDTO;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AQA_Makhortov.AutoTests;

public class UsersJsonTests
{
    private const double MinLat = 55.3;
    private const double MaxLat = 69.1;
    private const double MinLng = 10.9;
    private const double MaxLng = 24.2;
    
    private List<DataDTO> _users;
    
    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
        string json = File.ReadAllText(path);

        _users = JsonSerializer.Deserialize<UsersDTO>(json).Data;
    }

    [Test]
    public void Test1_CheckAllUsersAmount_Equals_10()
    {
        _users.Should().HaveCount(10);
    }
    
    [Test]
    public void Test2_CheckFirstUserFullName_IsAliceJohnson()
    {
        var firstUser =  _users.First();
        firstUser.Profile.FullName.Should().Be("Alice Johnson");
    }

    [Test]
    public void Test3_CheckAllUsersIdentifiers_AreUnique()
    {
        var usersId =  _users.Select(user => user.Id).ToList();
        usersId.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void Test4_CheckAtLeastOneUser_HasTagPremium()
    {
        var premiumUsers = _users.Where(user => user.Profile.Tags.Contains("premium")).ToList();
        premiumUsers.Should().NotBeNullOrEmpty();
    }
    
    [Test]
    public void Test5_CheckAllUsersCity_IsNotEmpty()
    {
        var usersCity = _users.Select(user => user.Profile.Address.City).ToList();
        usersCity.Should().OnlyContain(city => !string.IsNullOrWhiteSpace(city));
    }

    [Test]
    public void Test6_CheckAtLeastOneUser_HasCityStockholm()
    {
        var usersCity = _users.Where(user => user.Profile.Address.City == "Stockholm").ToList();
        usersCity.Should().NotBeNullOrEmpty();
    }
    
    [Test]
    public void Test7_CheckAllUsersAge_IsFrom18To60()
    {
        var usersAge = _users.Select(user => user.Profile.Age).ToList();
        usersAge.Should().OnlyContain(age => age >= 18 && age <= 60);
    }
    
    [Test]
    public void Test8_CheckAtLeastOneUser_HasRoleAdmin()
    {
        var usersRoles = _users.Where(user => user.Roles.Contains("admin")).ToList();
        usersRoles.Should().NotBeNullOrEmpty();
    }

    [Test]
    public void Test9_CheckAllUsersGeo_IsSweden()
    {
        var usersGeo = _users.Select(user => user.Profile.Address.Geo).ToList();
        usersGeo.Should().OnlyContain(geo => geo.Lat >= MinLat && geo.Lat <= MaxLat && geo.Lng >= MinLng && geo.Lng <= MaxLng);
    }
}