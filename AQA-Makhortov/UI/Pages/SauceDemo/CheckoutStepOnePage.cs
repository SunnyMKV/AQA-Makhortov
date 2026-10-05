using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class CheckoutStepOnePage
{
    private readonly IPage _page;

    private ILocator FirstNameInput => _page.GetByPlaceholder("First Name");
    private ILocator LastNameInput => _page.GetByPlaceholder("Last Name");
    private ILocator ZipOrPostalCodeInput => _page.GetByPlaceholder("Zip/Postal Code");
    private ILocator ContinueButton => _page.GetByText("Continue");
    
    public CheckoutStepOnePage(IPage page)
    {
        _page = page;
    }

    public async Task FillClientDeliveryDetailsAsync(string firstName, string lastName, string zipOrPostalCode)
    {
        await FirstNameInput.FillAsync(firstName);
        await LastNameInput.FillAsync(lastName);
        await ZipOrPostalCodeInput.FillAsync(zipOrPostalCode);
    }
    
    public async Task ClickContinueButtonAsync()
    {
        await ContinueButton.ClickAsync();
    }
}