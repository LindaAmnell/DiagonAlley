namespace DiagonAlley.UI
{
    public static class InputHelper
    {

        public static string AskForChoice(string message = "Choose a option: ")
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";

        }

        public static void Pause(string message = "Press any key to continue..")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static string AskForInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            return input;

        }

        public static string NonEmptyInput(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input cannot be empty. Please try again.\n");

            } while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }
        public static bool YesOrNo(string message)
        {
            string input;
            while (true)
            {
                Console.Write($"{message} (yes/no): ");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "yes" || input == "y")
                    return true;
                if (input == "no" || input == "n")
                    return false;

                Console.WriteLine("Please type 'yes' or 'no'.");
            }
        }



    }
}
