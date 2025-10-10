using DiagonAlley.Models.Customer;
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
            Console.WriteLine("Type E to exit");

            string name = AskForName();
            if (name == null) return null;

            string password = AskForPassword();
            if (password == null) return null;

            string role = AskForRole();
            string level = AskForLevel();

            Wizard w = CreateWizard(name, password, role, level);
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
            Console.WriteLine("Login to Diagon Alley");
            Console.WriteLine("(Type E to Exit)\n");

            string name = InputHelper.AskForNonEmptyInput("Enter name: ");
            if (name.Equals("E".ToLower()))
            {
                Console.WriteLine("\nLogin cancelled.");
                return null;
            }

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
            Console.WriteLine("(Type E to exit)");
            string password = InputHelper.AskForNonEmptyInput("Enter password: ");

            while (!w.VerifyPassword(password))
            {
                if (password.Equals("E".ToLower()))
                {
                    Console.WriteLine("\nLogin cancelled.");
                    InputHelper.Pause();
                    return null;
                }

                Console.WriteLine("Incorrect password. Try again...");
                password = InputHelper.AskForNonEmptyInput("Password (or type 'exit' to cancel): ");
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

        private string AskForName()
        {
            while (true)
            {
                string name = InputHelper.AskForNonEmptyInput("Enter username: ");

                if (name.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
                if (DataService.GetAllWizards().Any(w => w.Name.Equals(name)))
                {
                    Console.WriteLine("That username is already taken. Try another.\n");
                }
                if (name.Length < 2)
                {
                    Console.WriteLine("name must be at least 2 characters long.\n");
                }
                if (name.Contains(" "))
                {
                    Console.WriteLine("Name can´t have blank space \n");
                }

                return name;

            }
        }

        private string AskForPassword()
        {
            while (true)
            {
                string password = InputHelper.AskForNonEmptyInput("Enter password: ");

                if (password.Equals("E".ToLower()))
                {
                    return null;
                }

                if (password.Length < 2)
                {
                    Console.WriteLine("Password must be at least 2 characters long.\n");
                }
                if (password.Contains(" "))
                {
                    Console.WriteLine("Password can´t have blank space \n");
                }

                return password;

            }
        }

        private string AskForRole()
        {
            while (true)
            {
                Console.Write("Are you a witch or a wizard? ");
                string role = Console.ReadLine()?.Trim().ToLower();

                if (role == "witch" || role == "wizard")
                {
                    return role;
                }

                Console.WriteLine("Invalid choice. Please type 'witch' or 'wizard'.\n");
            }
        }

        private string AskForLevel()
        {
            while (true)
            {
                string level = Menu.ShowLevelMenu();

                if (level != "1" && level != "2" && level != "3" && level != "4")
                {
                    Console.WriteLine("Invalid choice. Please enter 1–4:");
                    level = Menu.ShowLevelMenu();
                }
                return level;
            }
        }
        private Wizard CreateWizard(string name, string password, string role, string level)
        {
            return level switch
            {
                "2" => new BronzeWizard(name, password, role),
                "3" => new SilverWizard(name, password, role),
                "4" => new GoldWizard(name, password, role),
                _ => new Wizard(name, password, role)
            };
        }

    }
}
