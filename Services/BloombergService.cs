namespace ExchangeRateApi.Services {
    public class BloombergService : BaseService {

        public override async Task<double> GetUSD(string currencyCode, int amount) {
            await _Page.GotoAsync($"https://www.bloomberg.com/quote/{currencyCode}USD:CUR");
            var exchangeRate = await _Page.QuerySelectorAsync(".priceText__0550103750").Result.InnerTextAsync();
            var convertedAmount = double.Parse(exchangeRate) * amount;
            _Playwright.Dispose();
            return convertedAmount;
        }
    }
}
