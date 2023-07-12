using Microsoft.Playwright;

namespace ExchangeRateApi.Services {
    public abstract class BaseService {
        public readonly IPage _Page;
        public readonly IPlaywright _Playwright;
        
        protected BaseService() {
            _Playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            _Page = SetupPage().GetAwaiter().GetResult();
        }

        private async Task<IPage> SetupPage() {
            //Playwright setup to not be detected as bot
            var browser = await _Playwright.Chromium.LaunchAsync();
            var context = await browser.NewContextAsync(new BrowserNewContextOptions { UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36" });
            var page = await context.NewPageAsync();
            await page.SetViewportSizeAsync(1600, 1600);
            return page;
        }

        public abstract Task<double> GetUSD(string currencyCode, int amount);
    }
}
