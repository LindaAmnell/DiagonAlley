using DiagonAlley.UI;

namespace DiagonAlley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScreenHelper.PrintHeader();
            var store = new StoreController();
            store.RunStore();
        }
    }
}
