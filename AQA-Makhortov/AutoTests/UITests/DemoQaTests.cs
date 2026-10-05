using AQA_Makhortov.UI.Pages.DemoQA;

namespace AQA_Makhortov.AutoTests.UITests;

public class DemoQaTests : BaseTest
{
    [Test] 
    public async Task SelectTitleOptionOption()
    {
        const string titleOption = "Prof.";
        
        SelectMenuPage selectMenuPage =  new SelectMenuPage(Page);
        await selectMenuPage.OpenSelectMenuPageAsync();
        await selectMenuPage.SelectOptionFromTitlesDropdown(titleOption);
        await selectMenuPage.CheckCorrespondenceOfChosenTitleOption(titleOption);
    }
}