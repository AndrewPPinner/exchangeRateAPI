namespace ExchangeRateApi.Models {
    public class CurrencyDictionaryModel {
        public DateTime Time { get; set; }
        public double ExchangeRate { get; set; }

        public CurrencyDictionaryModel(DateTime time, double exchangeRate) {
            Time = time;
            ExchangeRate = exchangeRate;
        }
    }
}
