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
        public static string ShowCustomerMenu(string customerName)
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine($"Welcome {customerName}!\n");

            Console.WriteLine("[1] Shop products");
            Console.WriteLine("[2] View cart");
            Console.WriteLine("[3] Checkout");
            Console.WriteLine("[4] Log out\n");


            return InputHelper.AskForChoice();
        }

        public static string ShowAllProductsMenu()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine("What magical item do you seek?");

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
                Console.Write("Would you like to go to the product menu? (yes/no): ");
                string answer = Console.ReadLine().Trim().ToLower();

                if (answer == "yes" || answer == "y")
                {
                    return "goToProducts";
                }

                return "3";
            }

            //Console.WriteLine("\n═══════════  Checkout ═══════════ ");
            Console.WriteLine("What would you like to do?");

            Console.WriteLine(" [1] Confirm purchase and pay       ");
            Console.WriteLine(" [2] Clear cart (remove all items)  ");
            Console.WriteLine(" [3] Cancel and go back\n             ");



            return InputHelper.AskForChoice();
        }

    }
}

