using DiagonAlley.Services;

namespace DiagonAlley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new StoreHelper();
            store.RunStore();
        }
    }
}
