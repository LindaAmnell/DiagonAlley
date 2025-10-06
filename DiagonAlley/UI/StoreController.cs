using DiagonAlley.Models;
using DiagonAlley.Services;

namespace DiagonAlley.UI
{
    public class StoreController
    {
        private readonly WizardService wizardService = new WizardService();
        public void RunStore()
        {
            bool running = true;

            while (running)
            {
                string choice = Menu.ShowMainMenu();
                switch (choice)
                {
                    case "1":
                        wizardService.RegisterCustomer();
                        break;
                    case "2":
                        var wizard = wizardService.LogIn();
                        if (wizard != null)
                        {
                            HandleCustomerMenu(wizard);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Exiting store.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }


            }
        }

        private void HandleCustomerMenu(Wizard w)
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                string customerChoice = Menu.ShowCustomerMenu(w.Name);
                switch (customerChoice)
                {
                    case "1":
                        ProductsMenu(w);
                        break;
                    case "2":
                        CartService.ShowCart(w);
                        InputHelper.Pause();
                        break;
                    case "3":
                        CheckoutMenu(w);
                        break;
                    case "4":
                        CurrencyMenuService.ChangeCurrencyMenu();
                        break;
                    case "5":
                        Console.WriteLine($"{w.Name} has exited Diagon Alley.");
                        Console.ReadKey();
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        private void ProductsMenu(Wizard w)
        {
            bool isShopping = true;

            while (isShopping)
            {
                string choice = Menu.ShowAllProductsMenu();
                (Product chosen, int amount) = (null, 0);
                switch (choice)
                {
                    case "1":
                        (chosen, amount) = ProductPrinter.ShowAllProducts<Wand>("Wand");
                        break;
                    case "2":
                        (chosen, amount) = ProductPrinter.ShowAllProducts<Potion>("Potion");
                        break;
                    case "3":
                        (chosen, amount) = ProductPrinter.ShowAllProducts<Broomstick>("Bromstick");
                        break;
                    case "4":
                        isShopping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
                if (chosen != null && amount > 0)
                {
                    w.AddToCart(chosen, amount);
                    Console.WriteLine($"{amount} x {chosen.Name} has been added to your cart!\n");
                    InputHelper.Pause();
                }
            }
        }

        private void CheckoutMenu(Wizard w)
        {
            bool stayInMenu = true;
            while (stayInMenu)
            {
                var checkoutChoice = Menu.ShowCheckoutMenu(w);

                switch (checkoutChoice)
                {
                    case "1":
                        CartService.ConfirmPurchase(w);
                        break;
                    case "2":
                        CartService.ClearWizardCart(w);
                        break;
                    case "3":
                        //Console.WriteLine("Returning to main menu...");
                        stayInMenu = false;
                        break;
                    case "goToProducts":
                        ProductsMenu(w);
                        stayInMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
            InputHelper.Pause();

        }
    }
}

