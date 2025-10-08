using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI
{
    public static class Menu
    {
        public static string ShowMainMenu()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine("[1] Create new customer");
            Console.WriteLine("[2] Sign in");
            Console.WriteLine("[3] Exit\n");

            return InputHelper.AskForChoice();
        }
        public static string ShowLevelMenu()
        {
            Console.WriteLine("\nChoose your level:");
            Console.WriteLine("[1] None (0% discount)");
            Console.WriteLine("[2] Bronze (5% discount)");
            Console.WriteLine("[3] Silver (10% discount)");
            Console.WriteLine("[4] Gold (15% discount)");
            Console.Write("Enter choice (1–4): ");

            return InputHelper.AskForChoice();
        }

        public static string ShowCustomerMenu(Wizard w, Currency currentCurrency)
        {
            Console.Clear();
            ScreenHelper.PrintHeader(w, currentCurrency);
            Console.WriteLine("\n[1] Shop products");
            Console.WriteLine("[2] View cart");
            Console.WriteLine("[3] Checkout");
            Console.WriteLine($"[4] Change currency (Current: {currentCurrency})");
            Console.WriteLine("[5] Log out\n");


            return InputHelper.AskForChoice();
        }

        public static string ShowAllProductsMenu()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine("What magical item do you seek?\n");
            Console.WriteLine("[1] Wand");
            Console.WriteLine("[2] Potion");
            Console.WriteLine("[3] BromStick");
            Console.WriteLine("[4] Exit shop\n");

            return InputHelper.AskForChoice();
        }

        public static string ShowCheckoutMenu(Wizard w)
        {
            ScreenHelper.RefreshScreen();
            CartService.ShowCart(w);

            if (w.Cart == null || w.Cart.Count == 0)
            {
                Console.WriteLine("\nYou need to buy something before you can checkout.");
                if (InputHelper.YesOrNo("Would you like to go to the product menu?"))
                {
                    return "goToProducts";
                }

                return "3";
            }

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Confirm purchase and pay");
            Console.WriteLine("[2] Clear cart (remove all items)");
            Console.WriteLine("[3] Cancel and go back\n");

            return InputHelper.AskForChoice();
        }

        public static Currency ChooseCurrency()
        {
            Console.WriteLine("\nSelect currency:");
            Console.WriteLine("1. SEK");
            Console.WriteLine("2. USD");
            Console.WriteLine("3. EUR");
            Console.Write("Choose: ");
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

