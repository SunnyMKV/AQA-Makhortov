using Microsoft.Playwright;

namespace AQA_Makhortov.UI
{
    public class PlaywrightFixture : IAsyncDisposable
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 3000,
                Args = ["--start-maximized"]
            });
        }

        public async ValueTask DisposeAsync()
        {
            if(Browser != null)
            {
                await Browser.CloseAsync();
            }
            Playwright?.Dispose();
        }
    }
}