using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class CheckoutCompletePage
{
    private readonly IPage _page;

    private ILocator SuccessfulCheckoutText => _page.GetByText("Thank you for your order!");
    
    public CheckoutCompletePage(IPage page)
    {
        _page = page;
    }

    public async Task CheckIfOrderIsCompletedAsync()
    {
        var actualSuccessfulCheckoutText = await SuccessfulCheckoutText.InnerTextAsync();
        actualSuccessfulCheckoutText.Should().Be("Thank you for your order!");
    }
}