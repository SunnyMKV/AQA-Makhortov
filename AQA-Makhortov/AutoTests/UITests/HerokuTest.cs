using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.AutoTests.UITests;

public class HerokuTests : BaseTest
{
    [Test]
    public async Task CheckBoxTest()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/checkboxes");
        var first = Page.Locator("input[type='checkbox']").Nth(0);
        await first.CheckAsync();
        (await first.IsCheckedAsync()).Should().BeTrue();
    }

    [Test]
    public async Task AuthentificationForm()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/login");
        var usernameField = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });
        await usernameField.FillAsync("wrong");
        var passwordField = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });
        await passwordField.FillAsync("wrong");
        var logInButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        await logInButton.ClickAsync();
        var invalidCredentialsMessageLabel = Page.Locator("//div[@id='flash']");
        var expectedInvalidCredentialsMessageLabel = await invalidCredentialsMessageLabel.InnerTextAsync();
        expectedInvalidCredentialsMessageLabel.Should().Contain("Your username is invalid!");
    }
}