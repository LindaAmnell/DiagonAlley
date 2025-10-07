using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class CurrencyConverter
    {
        private static readonly Dictionary<Currency, double> rates = new()
    {
            { Currency.SEK, 1.0 },
            { Currency.USD, 0.09 },
            { Currency.EUR, 0.085 }
    };

        public static double ConvertFromSEK(double amount, Currency toCurrency)
        {
            return amount * rates[toCurrency];
        }

        public static void ShowAvailableCurrencies()
        {
            Console.WriteLine("Tillgängliga valutor:");
            foreach (var c in rates)
            {
                Console.WriteLine($"- {c.Key} (kurs: {c.Value})");
            }
        }

        public static Currency ChooseCurrency()
        {
            Console.WriteLine("\nVälj valuta:");
            Console.WriteLine("1. SEK");
            Console.WriteLine("2. USD");
            Console.WriteLine("3. EUR");
            Console.Write("Val: ");
            string input = Console.ReadLine();

            return input switch
            {
                "1" => Currency.SEK,
                "2" => Currency.USD,
                "3" => Currency.EUR,
                _ => Currency.SEK
            };
        }

    }
}
