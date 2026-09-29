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

    [Test]
    public async Task DropDownTest()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/dropdown");
        await Assertions.Expect(Page).ToHaveTitleAsync("The Internet");
        await Assertions.Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/dropdown");
        var dropdown = Page.Locator("//select[@id='dropdown']");
        await Assertions.Expect(dropdown).ToBeVisibleAsync();
        await dropdown.SelectOptionAsync("1");
        await Assertions.Expect(dropdown).ToHaveValueAsync("1");
        var selectedOption = Page.Locator("option:checked");
        await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 1");
        dropdown = Page.Locator("//select[@id='dropdown']");
        await Assertions.Expect(dropdown).ToBeVisibleAsync();
        await dropdown.SelectOptionAsync("2");
        await Assertions.Expect(dropdown).ToHaveValueAsync("2");
        selectedOption = Page.Locator("option:checked");
        await Assertions.Expect(selectedOption).ToHaveTextAsync("Option 2");
    }

    [Test]
    public async Task Should_Select_Sub_Item()
    {
        await Page.GotoAsync("https://demoqa.com/select-menu");
        var dropdown = Page.Locator("#withOptGroup");
        await dropdown.ClickAsync();
        var option = Page.GetByText("Group 1, option 1");
        await option.ClickAsync();
        await Assertions.Expect(dropdown).ToContainTextAsync("Group 1, option 1");
    }
}