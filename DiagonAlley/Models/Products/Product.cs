using DiagonAlley.Services;
using DiagonAlley.UI;

namespace DiagonAlley.Models.Products
{
    public abstract class Product
    {
        public string Name { get; private set; }

        public double Price { get; private set; }


        public Product(string name, double price, int amount)
        {
            Name = name;
            Price = price;
        }

        protected string GetFormattedPrice()
        {
            return CurrencyConverter.Format(Price, StoreController.SelectedCurrency);
        }
    }
}
