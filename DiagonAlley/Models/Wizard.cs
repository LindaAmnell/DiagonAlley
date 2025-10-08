using DiagonAlley.Services;
using DiagonAlley.UI;

namespace DiagonAlley.Models
{
    public enum WizardLevel
    {
        Regular,
        Bronze,
        Silver,
        Gold
    }
    public class Wizard
    {
        public string Name { get; private set; }
        private string Password { get; set; }
        public string Role { get; private set; }
        public WizardLevel Level { get; protected set; } = WizardLevel.Regular;
        public double Discount { get; protected set; } = 0.0;

        private readonly List<CartItem> cart = new List<CartItem>();

        public IReadOnlyList<CartItem> Cart => cart;

        public Wizard(string name, string password, string role)
        {
            Name = name;
            Password = password;
            cart = new List<CartItem>();
            Role = role;
        }

        public virtual double ApplayDiscont(double total)
        {
            return total * (1 - Discount);
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public string GetPassword() => Password;

        public double CartTotal()
        {
            return cart.Sum(p => p.TotalPrice());
        }

        public void AddToCart(Product p, int amount)
        {
            if (p == null || amount <= 0)
            {
                return;
            }
            cart.Add(new CartItem(p, amount));

        }
        public void ClearCart()
        {
            cart.Clear();
        }

        public override string ToString()
        {
            if (cart.Count == 0)
                return $"Name: {Name} | Role: {Role} | Level: {Level}\n "
                    + "--Cart Empty--";

            string cartContent = "";
            double totalSEK = 0;

            foreach (CartItem c in cart)
            {
                double productTotalSEK = c.TotalPrice();
                double productTotalConverted = CurrencyConverter.ConvertFromSEK(productTotalSEK, StoreController.SelectedCurrency);

                cartContent += $"{c.Amount} x {c.Product.Name} = {productTotalConverted:F2} {StoreController.SelectedCurrency}\n";
                totalSEK += productTotalSEK;
            }

            string totalFormatted = CurrencyConverter.Format(totalSEK, StoreController.SelectedCurrency);

            return
                $"Name: {Name} | Role: {Role} | Level: {Level} | Password {Password}\n" +
                $"══════════════════════════════════════════════════════════════\n" +
                $"{cartContent}" +
                $"══════════════════════════════════════════════════════════════\n" +
                $"Total: {totalFormatted}\n";
        }
    }
}