using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public static class CartService
    {

        public static void ShowCart(Wizard w)
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine($"════════ {w.Name}'s Cart ════════");
            if (w.Cart.Count == 0)
            {
                Console.WriteLine(" Emty\n");
                return;
            }

            foreach (CartItem item in w.Cart)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"═══════════════════════════════");

            double totalSEK = w.CartTotal();
            double totalConverted = CurrencyConverter.ConvertFromSEK(totalSEK, StoreController.SelectedCurrency);
            Console.WriteLine($"Total: {totalConverted:F2} {StoreController.SelectedCurrency}\n");




        }

        public static void ConfirmPurchase(Wizard w, Currency selectedCurrency)
        {
            double totalSEK = w.CartTotal();
            double discountedTotalSEK = w.ApplayDiscont(totalSEK);

            double totalConverted = CurrencyConverter.ConvertFromSEK(totalSEK, selectedCurrency);
            double discountedConverted = CurrencyConverter.ConvertFromSEK(discountedTotalSEK, selectedCurrency);

            Console.WriteLine("\n═══════════ Diagon Alley Checkout ═══════════");
            Console.WriteLine($" Customer: {w.Name}");
            Console.WriteLine($" Level: {w.Level} — {w.Discount * 100}% discount");
            Console.WriteLine($" Original price: {totalConverted:F2} {selectedCurrency}");
            Console.WriteLine($" After discount: {discountedConverted:F2} {selectedCurrency}");
            Console.WriteLine("═════════════════════════════════════════════");
            Console.WriteLine("\nThank you for shopping at Diagon Alley!");

            w.ClearCart();
            InputHelper.Pause();
            Menu.ShowCustomerMenu(w.Name, selectedCurrency);
        }
        public static void ClearWizardCart(Wizard w, Currency currentCurrency)
        {
            w.ClearCart();
            Console.WriteLine("Your cart has been magically emptied.");
            InputHelper.Pause();
            Menu.ShowCustomerMenu(w.Name, currentCurrency);
        }



    }
}
