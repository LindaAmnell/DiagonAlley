namespace DiagonAlley.UI
{
    public static class InputHelper
    {

        public static string AskForChoice(string message = "Choose an option: ")
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }

        public static void Pause(string message = "Press any key to continue..")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
        public static string AskForNonEmptyInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.WriteLine("Input cannot be empty. Please try again.\n");
            }
        }

        public static bool YesOrNo(string message)
        {
            string input;
            while (true)
            {
                Console.Write($"{message} (yes/no): ");
                input = Console.ReadLine()?.Trim().ToLower();

                if (input == "yes" || input == "y")
                    return true;
                if (input == "no" || input == "n")
                    return false;

                Console.WriteLine("Please type 'yes' or 'no'.");
            }
        }
    }
}
