using Microsoft.Playwright;

namespace ExchangeRateApi.Services {
    public class OandaService : BaseService {

        public override async Task<double> GetUSD(string currencyCode, int amount) {
            await _Page.GotoAsync($"https://www.oanda.com/currency-converter/en/?from={currencyCode}&to=USD&amount={amount}");
            var result = await _Page.QuerySelectorAllAsync("[name=\"numberformat\"]").Result[1].GetAttributeAsync("value");
            _Playwright.Dispose();
            return Convert.ToDouble(result);
        }
    }
}
