using DiagonAlley.Models;
using DiagonAlley.UI;

namespace DiagonAlley.Services
{
    public class WizardService
    {

        public Wizard RegisterCustomer()
        {
            Console.Clear();
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

            Wizard w = new Wizard(name, password, role);
            DataService.AddWizard(w);

            Console.WriteLine($"\nWelcome to Diagon Alley, {role} {name}! You have been registered successfully.");
            InputHelper.Pause();
            return w;
        }

        public Wizard LogIn()
        {
            Console.Clear();
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

        private Wizard CheckPassword(Wizard wizard)
        {
            string password = InputHelper.AskForInput("Enter password: ");

            while (!wizard.VerifyPassword(password))
            {
                Console.WriteLine("Incorrect password. Try again...");
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome back, {wizard.Name}!");
            InputHelper.Pause();
            return wizard;
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
