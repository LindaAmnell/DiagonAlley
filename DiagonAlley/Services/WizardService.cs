using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public class WizardService
    {
        public Wizard RegisterCustomer()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine("Welcome to  Diagon Alley!");
            Console.WriteLine("Time for registration\n");

            string name = InputHelper.AskForInput("Enter username: ");
            string password = InputHelper.AskForInput("Enter password: ");

            Console.Write("\nAre you a witch or a wizard? ");
            string role = Console.ReadLine().ToLower();

            while (role != "witch" && role != "wizard")
            {
                Console.WriteLine("Invalid choice");
                Console.WriteLine("Please type 'witch' or 'wizard'");
                role = Console.ReadLine().ToLower();
            }

            Console.WriteLine("\nChoose your level:");
            Console.WriteLine("[1] None (0% discount)");
            Console.WriteLine("[2] Bronze (5% discount)");
            Console.WriteLine("[3] Silver (10% discount)");
            Console.WriteLine("[4] Gold (15% discount)");
            Console.Write("Enter choice (1–4): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter 1–4:");
            }

            Wizard w = choice switch
            {
                4 => new GoldWizard(name, password, role),
                3 => new SilverWizard(name, password, role),
                2 => new BronzeWizard(name, password, role),
                _ => new Wizard(name, password, role)
            };

            DataService.AddWizard(w);

            Console.WriteLine($"\nWelcome to Diagon Alley,¨{w.Level} {role} {name}! You have been registered successfully.");
            InputHelper.Pause();
            return w;
        }

        public Wizard LogIn()
        {
            ScreenHelper.RefreshScreen();
            Console.WriteLine("Login to Diagon Alley\n");

            string name = InputHelper.AskForChoice("Enter name: ");

            Wizard wizard = DataService.GetAllWizards().FirstOrDefault(w => w.Name == name);

            if (wizard != null)
            {
                return CheckPassword(wizard);
            }
            else
            {
                return RegisterIfNotFound();
            }

        }

        private Wizard CheckPassword(Wizard w)
        {
            string password = InputHelper.AskForInput("Enter password: ");

            while (!w.VerifyPassword(password))
            {
                Console.WriteLine("Incorrect password. Try again...");
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome back, {w.Level} member {w.Name} the {w.Role}!");

            InputHelper.Pause();
            return w;
        }

        private Wizard RegisterIfNotFound()
        {
            Console.WriteLine("Customer not found.");
            Console.Write("Do you want to register? (yes/no): ");

            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                return RegisterCustomer();
            }
            else
            {
                Console.WriteLine("Exiting login.");
                InputHelper.Pause();
                return null;
            }
        }
    }
}

