using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.SauceDemo;

public class InventoryPage
{
    private readonly IPage _page;

    private ILocator ProductsTitle => _page.Locator("[data-test='title']");

    private ILocator AddToCartButton(string itemName) => _page.Locator(".inventory_item")
        .Filter(new() { HasText = itemName })
        .GetByRole(AriaRole.Button, new() { Name = "Add to cart" });

    private ILocator CartButton => _page.Locator("[data-test='shopping-cart-link']");

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    public async Task CheckIfInventoryPageIsOpenedAsync()
    {
        var actualTitle = await ProductsTitle.InnerTextAsync();
        actualTitle.Should().Contain("Products");
    }

    public async Task AddItemToCartAsync(string itemName)
    {
        await AddToCartButton(itemName).ClickAsync();
    }
    
    public async Task ClickCartButtonAsync()
    {
        await CartButton.ClickAsync();
    }
}