using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI

{
    public class ProductPrinter
    {
        public static (Product, int) ShowAllProducts<T>(string type) where T : Product
        {
            ScreenHelper.RefreshScreen();
            var products = DataService.GetProductByType<T>();

            string title = $" {type.ToUpper()} SHOP ";
            string border = new string('═', title.Length);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║{title}║");
            Console.WriteLine($"╚{border}╝\n");
            Console.ResetColor();

            PrintHeaderFor<T>();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {products[i]}");
            }
            Console.WriteLine($"[0] Exit");

            int choice;
            while (true)
            {
                Console.Write("\nSelect an item to buy: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= 0 && choice <= products.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please eenter a number from the list.");
            }

            if (choice == 0)
            {
                return (null, 0);
            }

            var chosen = products[choice - 1];

            int amount;

            while (true)
            {
                Console.Write("\nHow many do you whant to buy: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out amount) && amount > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
            return (chosen, amount);
        }


        private static void PrintHeaderFor<T>() where T : Product
        {
            if (typeof(T) == typeof(Wand))
            {
                Console.WriteLine($"{"Name",-22} | {"Core",-20} | {"Length",6} | {"Price",12} |");
                Console.WriteLine(new string('-', 70));
            }
            else if (typeof(T) == typeof(Potion))
            {
                Console.WriteLine($"{"Name",-22} | {"Effect",-16} | {"Duration",10} | {"Price",12} |");
                Console.WriteLine(new string('-', 70));
            }
            else if (typeof(T) == typeof(Broomstick))
            {
                Console.WriteLine($"{"Name",-22} | {"Model",-26} | {"Speed",9} | {"Price",12} |");
                Console.WriteLine(new string('-', 80));
            }
            else
            {
                Console.WriteLine($"{"Name",-18} | {"Price",12}");
                Console.WriteLine(new string('-', 34));
            }
        }

    }
}
