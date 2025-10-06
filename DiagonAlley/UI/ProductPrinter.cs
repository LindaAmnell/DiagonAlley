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

            Console.WriteLine($" ═══════════ {type} ═══════════\n ");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"[{i + 1}].{products[i]}");
            }
            Console.WriteLine($"[0]. Exit");

            int choice;
            while (true)
            {
                Console.Write("What do you whant to buy: ");
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

    }
}
