using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class CartPage
{
    private readonly IPage _page;
    
    private ILocator ItemNameLabel(string itemName) => _page.Locator(".inventory_item_name")
        .Filter(new() { HasText = itemName });

    private ILocator CheckoutButton => _page.GetByText("Checkout");
    
    public CartPage(IPage page)
    {
        _page = page;
    }

    public async Task CheckIfCartContainsItemAsync(string itemName)
    {
        var actualItemName = await ItemNameLabel(itemName).InnerTextAsync();
        actualItemName.Should().Be(itemName);
    }

    public async Task ClickCheckoutButtonAsync()
    {
        await CheckoutButton.ClickAsync();
    }
}