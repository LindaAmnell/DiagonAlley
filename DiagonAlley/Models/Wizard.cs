namespace DiagonAlley.Models
{

    public enum WizardLevel
    {
        None,
        Bronze,
        Silver,
        Gold
    }
    public class Wizard
    {
        public string Name { get; private set; }
        private string Password { get; set; }
        public string Role { get; private set; }
        public WizardLevel Level { get; protected set; } = WizardLevel.None;
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
                return $"Name: {Name} | Password: {Password} | Cart: Empty";

            string cartContent = "";
            double total = 0;

            foreach (CartItem c in cart)
            {
                double productTotal = c.TotalPrice();
                cartContent += $"{c.Amount} x {c.Product.Name} = {productTotal}\n";
                total += productTotal;
            }

            return $"Name: {Role} [{Level}] {Name} | Password: {Password}\n" +
                   "----- Cart -----\n" +
                   $"{cartContent}" +
                   $"----------------\n" +
                   $"Total: {total}";
        }

    }
}