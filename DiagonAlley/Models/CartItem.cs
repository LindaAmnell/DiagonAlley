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

        public override string ToString()
        {
            double totalSek = TotalPrice();
            double converted = CurrencyConverter.ConvertFromSEK(totalSek, StoreController.SelectedCurrency);
            return $"{Amount} x {Product.Name} = {converted:F2} {StoreController.SelectedCurrency}";
        }


    }
}
