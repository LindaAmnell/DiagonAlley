using DiagonAlley.Services;

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
            string formattedPrice = CurrencyService.FormatPrice(totalSek);
            return $"{Amount} x {Product.Name} = {formattedPrice}";
        }

    }
}
