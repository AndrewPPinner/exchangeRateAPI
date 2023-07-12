using Microsoft.VisualBasic;

namespace ExchangeRateApi.Services {
    public class GoogleService : BaseService {

        public override async Task<double> GetUSD(string currencyCode, int amount) {
            await _Page.GotoAsync($"https://www.google.com/search?q={amount}+{currencyCode}+to+usd");
            var div1 = await _Page.QuerySelectorAsync(".dDoNo");
            var div2 = await div1.QuerySelectorAsync(".DFlfde");
            var convertedAmount = await div2.GetAttributeAsync("data-value");
            _Playwright.Dispose();
           return Convert.ToDouble(convertedAmount);
        }
    }
}
