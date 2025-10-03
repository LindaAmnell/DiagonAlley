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





    }
}
