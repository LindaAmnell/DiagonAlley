using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public static class CartService
    {

        public static void ShowCart(Wizard w)
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine(w.ToString());
        }

        public static void ConfirmPurchase(Wizard w, Currency selectedCurrency)
        {
            ScreenHelper.RefreshScreen();
            double totalSEK = w.CartTotal();
            double discountedTotalSEK = w.ApplayDiscont(totalSEK);

            double totalConverted = CurrencyConverter.ConvertFromSEK(totalSEK, selectedCurrency);
            double discountedConverted = CurrencyConverter.ConvertFromSEK(discountedTotalSEK, selectedCurrency);

            Console.WriteLine("═══════════ Diagon Alley Checkout ═══════════");
            Console.WriteLine($" Customer: {w.Name}");
            Console.WriteLine($" Level: {w.Level} — {w.Discount * 100}% discount");
            Console.WriteLine($" Original price: {totalConverted:F2} {selectedCurrency}");
            Console.WriteLine($" After discount: {discountedConverted:F2} {selectedCurrency}");
            Console.WriteLine("═════════════════════════════════════════════\n");

            if (!InputHelper.YesOrNo("Do you want to confirm your purchase?"))
            {
                Console.WriteLine("\nPurchase cancelled.");
                InputHelper.Pause();
                return;
            }

            Console.WriteLine("\nThank you for shopping at Diagon Alley!");
            w.ClearCart();
            InputHelper.Pause();
            return;
        }
        public static void ClearWizardCart(Wizard w, Currency currentCurrency)
        {
            ScreenHelper.RefreshScreen();
            if (!InputHelper.YesOrNo("Are you sure you want to empty your cart?"))
            {
                Console.WriteLine("\nCart was not cleared.");
                InputHelper.Pause();
                return;
            }

            w.ClearCart();
            Console.WriteLine("Your cart has been magically emptied.");
            InputHelper.Pause();
        }
    }
}
