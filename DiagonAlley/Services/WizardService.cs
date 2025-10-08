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

            string name;
            while (true)
            {
                name = InputHelper.AskForInput("Enter username: ");

                if (DataService.GetAllWizards().Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("That username is already taken. Please choose another one.\n");
                }
                else
                {
                    break;
                }
            }
            string password;
            while (true)
            {
                password = InputHelper.AskForInput("Enter password: ");

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password cannot be empty. Please try again.\n");
                }
                else if (password.Length < 2)
                {
                    Console.WriteLine("Password must be at least 2 characters long. Please try again.\n");
                }
                else
                {
                    break;
                }
            }

            Console.Write("\nAre you a witch or a wizard? ");
            string role = Console.ReadLine().ToLower();

            while (role != "witch" && role != "wizard")
            {
                Console.WriteLine("Invalid choice");
                Console.WriteLine("Please type 'witch' or 'wizard'");
                role = Console.ReadLine().ToLower();
            }

            string levelChoice = Menu.ShowLevelMenu();

            while (levelChoice != "1" && levelChoice != "2" && levelChoice != "3" && levelChoice != "4")
            {
                Console.WriteLine("Invalid choice. Please enter 1–4:");
                levelChoice = Menu.ShowLevelMenu();
            }

            Wizard w = levelChoice switch
            {
                "4" => new GoldWizard(name, password, role),
                "3" => new SilverWizard(name, password, role),
                "2" => new BronzeWizard(name, password, role),
                _ => new Wizard(name, password, role)
            };

            DataService.AddWizard(w);

            Console.WriteLine($"\nWelcome to Diagon Alley, {w.Level} {role} {name}! You have been registered successfully.");

            if (InputHelper.YesOrNo("Would you like to log in now?"))
            {
                Console.WriteLine("\nLogging you in...");
                InputHelper.Pause();
                return w;
            }
            else
            {
                Console.WriteLine("\nAlright! You can log in later from the main menu.");
                InputHelper.Pause();
                return null;
            }
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
            string password = InputHelper.AskForInput("Enter password (or type 'exit' to cancel): ");

            while (!w.VerifyPassword(password))
            {
                if (string.Equals(password, "exit", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("\nLogin cancelled.");
                    InputHelper.Pause();
                    return null;
                }

                Console.WriteLine("Incorrect password. Try again...");
                password = InputHelper.AskForInput("Password (or type 'exit' to cancel): ");
            }

            Console.WriteLine($"\nWelcome back, {w.Level} member {w.Name} the {w.Role}!\n");

            InputHelper.Pause();
            return w;
        }


        private Wizard RegisterIfNotFound()
        {
            Console.WriteLine("Customer not found.");

            if (InputHelper.YesOrNo("Do you want to register?"))
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

