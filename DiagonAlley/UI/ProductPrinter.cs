using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI

{
    public class ProductPrinter
    {
        public static (Product, int) ShowAllProducts<T>(string type) where T : Product
        {
            var products = DataService.GetProductByType<T>();

            Console.WriteLine($" ----- {type} ----- ");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]. {products[i]}");
            }
            Console.WriteLine($"[0]. Exit");

            Console.Write("What do you whant to buy: "); // chrash
            int choice = int.Parse(Console.ReadLine());


            if (choice == 0)
            {
                return (null, 0);
            }

            var chosen = products[choice - 1];

            Console.Write("\nHow many do you whant to buy: ");
            int amount = int.Parse(Console.ReadLine());

            return (chosen, amount);

        }

    }
}
