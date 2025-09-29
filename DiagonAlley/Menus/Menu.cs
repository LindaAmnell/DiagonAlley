namespace DiagonAlley.Menus
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

            Console.Write("Choose: ");
            return Console.ReadLine() ?? "";
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
            Console.Write("Choose: ");
            return Console.ReadLine() ?? "";
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
            Console.Write("Choose: ");
            return Console.ReadLine() ?? "";

        }

    }
}

