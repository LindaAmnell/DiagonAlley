using DiagonAlley.UI;

namespace DiagonAlley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            ScreenHelper.PrintHeader();
            var store = new StoreController();
            store.RunStore();
        }
    }
}
