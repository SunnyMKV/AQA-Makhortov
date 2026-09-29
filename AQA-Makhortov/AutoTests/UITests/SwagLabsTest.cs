using FluentAssertions;

namespace AQA_Makhortov.AutoTests.UITests;

public class SwagLabsTest : BaseTest
{
    [Test]
    public async Task LoginSuccessTest()
    {
        await Page.GotoAsync("https://www.saucedemo.com//");
        var usernameField = Page.GetByPlaceholder("Username");
        await usernameField.FillAsync("standard_user");
        var passwordField = Page.GetByPlaceholder("Password");
        await passwordField.FillAsync("secret_sauce");
        var loginButton = Page.GetByText("Login");
        await loginButton.ClickAsync();
        var title = Page.Locator("[data-test='title']");
        var expectedTitle = await title.InnerTextAsync();
        expectedTitle.Should().Contain("Products");
    }
}