using DiagonAlley.Models.Products;
using DiagonAlley.Services;
using DiagonAlley.UI;

namespace DiagonAlley.Models
{
    public class CartItem
    {

        public Product Product { get; private set; }
        public int Amount { get; private set; }

        public CartItem(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }

        public double TotalPrice()
        {
            return Product.Price * Amount;
        }
        public void AddAmount(int amount)
        {
            if (amount > 0) Amount += amount;
        }

        public override string ToString()
        {
            double totalSek = TotalPrice();
            string unitFormatted = CurrencyConverter.Format(Product.Price, StoreController.SelectedCurrency);
            string totalFormatted = CurrencyConverter.Format(totalSek, StoreController.SelectedCurrency);
            return $"{Product.Name} {unitFormatted} x {Amount} = {totalFormatted}";
        }



    }
}
