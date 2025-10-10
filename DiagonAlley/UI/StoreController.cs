using DiagonAlley.Models;
using DiagonAlley.Models.Customer;
using DiagonAlley.Models.Products;
using DiagonAlley.Services;

namespace DiagonAlley.UI
{
    public static class StoreController
    {
        public static Currency SelectedCurrency { get; private set; } = Currency.SEK;

        private static readonly WizardService wizardService = new WizardService();
        public static void RunStore()
        {
            bool running = true;

            while (running)
            {
                string choice = Menu.ShowMainMenu();
                switch (choice)
                {
                    case "1":
                        var newWizard = wizardService.RegisterCustomer();
                        if (newWizard != null)
                        {
                            HandleCustomerMenu(newWizard);
                        }
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
                        InputHelper.Pause();
                        break;
                }
            }
        }

        private static void HandleCustomerMenu(Wizard w)
        {
            bool loggedIn = true;
            while (loggedIn)
            {
                string customerChoice = Menu.ShowCustomerMenu(w, SelectedCurrency);
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
                        SelectedCurrency = CurrencyMenu();
                        break;
                    case "5":
                        Console.WriteLine($"{w.Name} has exited Diagon Alley.");
                        Console.ReadKey();
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        InputHelper.Pause();
                        break;
                }
            }
        }

        private static void ProductsMenu(Wizard w)
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
                        (chosen, amount) = ProductPrinter.ShowAllProducts<Broomstick>("Broomstick");
                        break;
                    case "4":
                        isShopping = false;
                        Console.WriteLine("Leaving shop..");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        InputHelper.Pause();
                        break;
                }
                if (chosen != null && amount > 0)
                {
                    w.AddToCart(chosen, amount);
                    Console.WriteLine($"\n{amount} x {chosen.Name} has been added to your cart!\n");
                    InputHelper.Pause();
                }
            }
        }

        private static void CheckoutMenu(Wizard w)
        {
            bool stayInMenu = true;
            while (stayInMenu)
            {
                var checkoutChoice = Menu.ShowCheckoutMenu(w);

                switch (checkoutChoice)
                {
                    case "1":
                        CartService.ConfirmPurchase(w, SelectedCurrency);
                        stayInMenu = false;
                        break;
                    case "2":
                        CartService.ClearWizardCart(w);
                        stayInMenu = false;
                        break;
                    case "3":
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
        }

        private static Currency CurrencyMenu()
        {
            while (true)
            {
                Currency chosenCurrency;
                string input = Menu.ChooseCurrency();

                switch (input)
                {
                    case "1":
                        chosenCurrency = Currency.SEK;
                        break;
                    case "2":
                        chosenCurrency = Currency.USD;
                        break;
                    case "3":
                        chosenCurrency = Currency.EUR;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Please enter 1, 2, or 3.\n");
                        continue;
                }
                Console.WriteLine($"\nYou selected: {chosenCurrency}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                return chosenCurrency;
            }
        }
    }
}

