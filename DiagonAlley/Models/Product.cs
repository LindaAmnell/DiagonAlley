using DiagonAlley.Services;

namespace DiagonAlley.Models
{
    public abstract class Product
    {

        public string Name { get; private set; }

        public double Price { get; private set; }

        public int Amount { get; private set; }

        public Product(string name, double price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public double TotalPrice()
        {
            return Price * Amount;
        }
        public string GetFormattedPrice()
        {
            double convertedPrice = CurrencyService.ConvertPrice(Price);
            string symbol = CurrencyService.GetCurrencySymbol();
            return $"{convertedPrice:F2} {symbol}";
        }




    }
}
