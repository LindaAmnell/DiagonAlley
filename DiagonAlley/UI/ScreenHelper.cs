using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI
{
    public static class ScreenHelper
    {

        public static void PrintHeader(Wizard wizard = null, Currency currency = Currency.SEK)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("             DIAGON ALLEY             ");
            Console.WriteLine("══════════════════════════════════════\n");
            Console.ResetColor();

            if (wizard != null)
            {
                int totalItems = wizard.Cart.Sum(c => c.Amount);
                double totalSEK = wizard.CartTotal();
                string totalFormatted = CurrencyConverter.Format(totalSEK, currency);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Logged in as: {wizard.Name} | Items in cart: {totalItems} | Total: {totalFormatted}");
                Console.ResetColor();
                Console.WriteLine("───────────────────────────────────────────────────────────────────");
            }
        }


        public static void ClearBelowHeader(int startLine = 4)
        {
            for (int i = startLine; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, startLine);
        }


        public static void RefreshScreen()
        {
            Console.Clear();
            PrintHeader();
            Console.SetCursorPosition(0, 4);
        }

    }



}
