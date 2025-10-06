namespace DiagonAlley.UI
{
    public static class ScreenHelper
    {

        public static void PrintHeader()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║             DIAGON ALLEY             ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();
        }


        public static void ClearBelowHeader(int startLine = 4)
        {
            for (int i = startLine; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, startLine);
        }


        public static void RefreshScreen()
        {
            Console.Clear();
            PrintHeader();
            Console.SetCursorPosition(0, 4);
        }
    }



}
