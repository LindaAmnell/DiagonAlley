using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI
{
    public static class Menu
    {
        public static string ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ [1] Create new customer       ║");
            Console.WriteLine("║ [2] Sign in                   ║");
            Console.WriteLine("║ [3] Exit                      ║");
            Console.WriteLine("╚═══════════════════════════════╝\n");

            return InputHelper.AskForChoice();
        }
        public static string ShowCustomerMenu(string customerName)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {customerName}!");
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ [1] Shop products             ║");
            Console.WriteLine("║ [2] View cart                 ║");
            Console.WriteLine("║ [3] Checkout                  ║");
            Console.WriteLine("║ [4] Log out                   ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            return InputHelper.AskForChoice();
        }

        public static string ShowAllProductsMenu()
        {
            Console.Clear();
            Console.WriteLine("What magical item do you seek?");
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║ [1] Wand                      ║");
            Console.WriteLine("║ [2] Potion                    ║");
            Console.WriteLine("║ [3] BromStick                 ║");
            Console.WriteLine("║ [4] Exit shop                 ║");
            Console.WriteLine("╚═══════════════════════════════╝");

            return InputHelper.AskForChoice();

        }

        public static string ShowCheckoutMenu(Wizard wizard)
        {
            Console.Clear();
            CartService.ShowCart(wizard);
            Console.WriteLine("\n----- Checkout -----");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║ [1] Confirm purchase and pay       ║");
            Console.WriteLine("║ [2] Clear cart (remove all items)  ║");
            Console.WriteLine("║ [3] Cancel and go back             ║");
            Console.WriteLine("╚════════════════════════════════════╝");

            return InputHelper.AskForChoice();
        }

    }
}

