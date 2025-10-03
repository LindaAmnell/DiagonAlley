using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public static class CartService
    {

        public static void ShowCart(Wizard wizard)
        {
            Console.WriteLine($"--- {wizard.Name}'s Cart ---");
            if (wizard.Cart.Count == 0)
            {
                Console.WriteLine("Your cart is emty..");
                return;
            }

            foreach (CartItem item in wizard.Cart)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------");
            Console.WriteLine($"Total: {wizard.CartTotal()} kr");
            InputHelper.Pause();
        }

        public static void ConfirmPurchase(Wizard wizard)
        {
            Console.WriteLine($"Thank you {wizard.Name}, your payment of {wizard.CartTotal()} kr has been received!");
            Console.WriteLine("Your items will be delivered by owl.");
            wizard.ClearCart();

        }
        public static void ClearWizardCart(Wizard wizard)
        {
            wizard.ClearCart();
            Console.WriteLine("Your cart has been magically emptied.");
        }


    }
}
