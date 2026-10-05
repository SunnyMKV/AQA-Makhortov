using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class LoginPage
{
    private readonly IPage _page;

    private ILocator UserNameTextBox => _page.GetByPlaceholder("Username");
    private ILocator PasswordTextBox => _page.GetByPlaceholder("Password");
    private ILocator LoginButton => _page.GetByText("Login");

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task OpenLoginPageAsync()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }

    public async Task LoginAsync(string username, string password)
    {
        await UserNameTextBox.FillAsync(username);
        await PasswordTextBox.FillAsync(password);
        await LoginButton.ClickAsync();
    }
}