using AQA_Makhortov.UI.Pages.SauceDemo;

namespace AQA_Makhortov.AutoTests.UITests;

public class SauceDemoTests : BaseTest
{
    [Test]
    public async Task PurchaseTwoItemsOrderCompletedSuccessfully_E2E()
    {
        const string firstTestItemName = "Sauce Labs Fleece Jacket";
        const string secondTestItemName = "Sauce Labs Bolt T-Shirt";

        LoginPage loginPage = new LoginPage(Page);
        await loginPage.OpenLoginPageAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");
        
        InventoryPage inventoryPage = new InventoryPage(Page);
        await inventoryPage.CheckIfInventoryPageIsOpenedAsync();
        await inventoryPage.AddItemToCartAsync(firstTestItemName);
        await inventoryPage.AddItemToCartAsync(secondTestItemName);
        await inventoryPage.ClickCartButtonAsync();
        
        CartPage cartPage = new CartPage(Page);
        await cartPage.CheckIfCartContainsItemAsync(firstTestItemName);
        await cartPage.CheckIfCartContainsItemAsync(secondTestItemName);
        await cartPage.ClickCheckoutButtonAsync();

        CheckoutStepOnePage checkoutStepOnePage = new CheckoutStepOnePage(Page);
        await checkoutStepOnePage.FillClientDeliveryDetailsAsync("Jensen", "Huang", "143 00");
        await checkoutStepOnePage.ClickContinueButtonAsync();
        
        CheckoutStepTwoPage checkoutStepTwoPage = new CheckoutStepTwoPage(Page);
        await checkoutStepTwoPage.CheckIfOrderContainsItemAsync(firstTestItemName);
        await checkoutStepTwoPage.CheckIfOrderContainsItemAsync(secondTestItemName);
        await checkoutStepTwoPage.ClickFinishButtonAsync();
        
        CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage(Page);
        await checkoutCompletePage.CheckIfOrderIsCompletedAsync();
    }
}