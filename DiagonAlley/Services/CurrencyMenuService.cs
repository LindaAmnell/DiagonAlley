using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public static class CurrencyMenuService
    {

        public static void ChangeCurrencyMenu()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine($" ════════ Change Currency ════════");
            var currencies = CurrencyService.GetAvailableCurrencies();
            Console.WriteLine("\nAvailable currencies:");
            foreach (var c in currencies)
            {
                Console.WriteLine($"- {c}");
            }

            Console.Write("\nEnter currency (SEK/USD/EUR): ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (Enum.TryParse(input, out Currency selectedCurrency))
            {
                CurrencyService.SetCurrency(selectedCurrency);
                string symbol = CurrencyService.GetCurrencySymbol();
                Console.WriteLine($"\nCurrency changed to {CurrencyService.CurrentCurrency} ({symbol})");
            }
            else
            {
                Console.WriteLine("Invalid currency.");
            }

            InputHelper.Pause();
        }

    }
}
