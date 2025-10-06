using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class CurrencyService
    {

        public static Currency CurrentCurrency { get; private set; } = Currency.SEK;


        private static readonly Dictionary<Currency, double> exchangeRates = new()
        {
            { Currency.SEK, 1.0 },
            { Currency.USD, 0.09 },
            { Currency.EUR, 0.085 }
        };


        public static List<Currency> GetAvailableCurrencies() => exchangeRates.Keys.ToList();


        public static void SetCurrency(Currency newCurrency)
        {
            if (exchangeRates.ContainsKey(newCurrency))
                CurrentCurrency = newCurrency;
            else
                Console.WriteLine("Currency not supported.");
        }


        public static double ConvertPrice(double sekPrice)
        {
            return sekPrice * exchangeRates[CurrentCurrency];
        }


        public static string GetCurrencySymbol()
        {
            return CurrentCurrency switch
            {
                Currency.USD => "$",
                Currency.EUR => "€",
                _ => "kr"
            };
        }

        public static string FormatPrice(double sekPrice)
        {
            double converted = ConvertPrice(sekPrice);
            string symbol = GetCurrencySymbol();
            return $"{converted:F2} {symbol}";
        }

    }
}
