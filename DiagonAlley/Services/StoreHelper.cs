using DiagonAlley.Menus;
using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public class StoreHelper
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

        private void HandleCustomerMenu(Wizard wizard)
        {

            bool loggedIn = true;

            string customerChoice = Menu.ShowCustomerMenu(wizard.Name);

            while (loggedIn)
            {
                switch (customerChoice)
                {
                    case "1":
                        // Shop products
                        break;
                    case "2":
                        // View cart
                        break;
                    case "3":
                        // Checkout
                        break;
                    case "4":
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }

            }

        }

        private void ProductsMenu()
        {
            bool isShopping = true;

            string choice = Menu.ShowAllProductsMenu();
            while (isShopping)
            {

                switch (choice)
                {
                    case "1":
                        //Wand
                        break;
                    case "2":
                        //Potion
                        break;
                    case "3":
                        //bromstick
                        break;
                    case "4":
                        isShopping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }
    }
}

