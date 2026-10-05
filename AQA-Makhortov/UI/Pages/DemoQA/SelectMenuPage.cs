using FluentAssertions;
using Microsoft.Playwright;

namespace AQA_Makhortov.UI.Pages.DemoQA;

public class SelectMenuPage
{
    private readonly IPage _page;
    
    private ILocator OpenSelectTitleDropdown => _page.Locator("[id='react-select-3-input']");
    private ILocator TitleOptionInDropdown(string titleOption) => _page.GetByText(titleOption);
    private ILocator SelectedTitleOptionFromDropdown(string titleOption) => _page.GetByText(titleOption, new() { Exact = true });
    
    public SelectMenuPage(IPage page)
    {
        _page = page;
    }
    
    public async Task OpenSelectMenuPageAsync()
    {
        await _page.GotoAsync("https://demoqa.com/select-menu");
    }

    public async Task SelectOptionFromTitlesDropdown(string titleOption)
    {
        await OpenSelectTitleDropdown.ClickAsync();
        await TitleOptionInDropdown(titleOption).ClickAsync();
    }

    public async Task CheckCorrespondenceOfChosenTitleOption(string titleOption)
    {
        var actualSelectedOptionFromDropdown = await SelectedTitleOptionFromDropdown(titleOption).InnerTextAsync();
        actualSelectedOptionFromDropdown.Should().Be(titleOption);
    }
}