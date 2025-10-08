using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class CurrencyConverter
    {

        public static double ConvertFromSEK(double amount, Currency toCurrency)
        {
            return amount / (int)toCurrency;
        }
        private static string GetSymbol(Currency currency)
        {
            return currency switch
            {
                Currency.SEK => "kr",
                Currency.USD => "$",
                Currency.EUR => "€",
                _ => ""
            };
        }


        public static void ShowAvailableCurrencies()
        {
            Console.WriteLine("\nAvailable currencies:");
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                Console.WriteLine($"- {currency} ({GetSymbol(currency)})");
            }
        }


        public static string Format(double amount, Currency currency)
        {
            double converted = ConvertFromSEK(amount, currency);
            string symbol = GetSymbol(currency);

            return $"{converted:F2} {symbol}";
        }
    }
}

