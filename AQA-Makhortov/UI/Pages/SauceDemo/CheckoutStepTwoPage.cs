using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class CheckoutStepTwoPage
{
    private readonly IPage _page;
    
    private ILocator ItemNameLabel(string itemName) => _page.Locator(".inventory_item_name")
        .Filter(new() { HasText = itemName });

    private ILocator FinishButton => _page.GetByText("Finish");
    
    public CheckoutStepTwoPage(IPage page)
    {
        _page = page;
    }

    public async Task CheckIfOrderContainsItemAsync(string itemName)
    {
        var actualItemName = await ItemNameLabel(itemName).InnerTextAsync();
        actualItemName.Should().Be(itemName);
    }

    public async Task ClickFinishButtonAsync()
    {
        await FinishButton.ClickAsync();
    }
}