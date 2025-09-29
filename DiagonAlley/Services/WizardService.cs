using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public class WizardService
    {
        private List<Wizard> wizardList = new List<Wizard>();

        public Wizard RegisterCustomer()
        {
            Console.Clear();
            Console.WriteLine("Welcome to  Diagon Alley!");
            Console.WriteLine("Time for registration\n");
            Console.Write("What's your name: ");
            string name = Console.ReadLine();
            Console.Write("\nWhat's your password: ");
            string password = Console.ReadLine();

            Console.Write("\nAre you a witch or a wizard? ");
            string role = Console.ReadLine().ToLower();

            while (role != "witch" && role != "wizard")
            {
                Console.WriteLine("ivalid choie");
                Console.WriteLine("pleas type witch or wizard");
                role = Console.ReadLine().ToLower();
            }

            Wizard w = new Wizard(name, password, role);
            wizardList.Add(w);

            Console.WriteLine($"\nWelcome to Diagon Alley, {role} {name}! You have been registered successfully.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return w;
        }

        public Wizard LogIn()
        {
            Console.Clear();

            Console.WriteLine("Login to Diagon Alley\n");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Wizard wizard = wizardList.FirstOrDefault(w => w.Name == name);

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
            Console.Write("Password: ");
            string password = Console.ReadLine();

            while (!wizard.VerifyPassword(password))
            {
                Console.WriteLine("Incorrect password. Try again...");
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome back, {wizard.Name}!");

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
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return null;
            }
        }
    }
}
