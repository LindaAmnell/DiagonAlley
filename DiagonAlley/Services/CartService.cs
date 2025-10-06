using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public static class CartService
    {

        public static void ShowCart(Wizard w)
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine($" ════════ {w.Name}'s Cart ════════");
            if (w.Cart.Count == 0)
            {
                Console.WriteLine(" Emty\n");
                return;
            }

            foreach (CartItem item in w.Cart)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine("══════════════════════ ");
            Console.WriteLine($"Total: {w.CartTotal()} kr");

        }

        public static void ConfirmPurchase(Wizard w)
        {
            double total = w.CartTotal();
            double discountedTotal = w.ApplayDiscont(total);

            ScreenHelper.RefreshScreen();
            Console.WriteLine("═══════════ Diagon Alley Checkout ═══════════");
            Console.WriteLine($" Customer: {w.Name}");
            Console.WriteLine($" Level: {w.Level} — {w.Discount * 100}% discount");
            Console.WriteLine($" Original price: {total:F2} kr");
            Console.WriteLine($" Discount: {(total - discountedTotal):F2} kr");
            Console.WriteLine($" Final amount: {discountedTotal:F2} kr");
            Console.WriteLine("═════════════════════════════════════════════");
            Console.WriteLine("\nThank you for shopping at Diagon Alley!");


            w.ClearCart();
            InputHelper.Pause();
            Menu.ShowCustomerMenu(w.Name);

        }
        public static void ClearWizardCart(Wizard w)
        {
            w.ClearCart();
            Console.WriteLine("Your cart has been magically emptied.");
            InputHelper.Pause();
            Menu.ShowCustomerMenu(w.Name);

        }


    }
}
