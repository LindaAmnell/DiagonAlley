namespace DiagonAlley.Models
{
    public class Wizard
    {
        public string Name { get; private set; }
        private string Password { get; set; }
        public string Role { get; private set; }

        private readonly List<CartItem> cart = new List<CartItem>();

        public IReadOnlyList<CartItem> Cart => cart;

        public Wizard(string name, string password, string role)
        {
            Name = name;
            Password = password;
            cart = new List<CartItem>();
            Role = role;
        }
        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

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
                cartContent += $"{c.Amount}kr x {c.Product.Name} = {productTotal}kr\n";
                total += productTotal;
            }

            return $"Name: {Role} {Name} | Password: {Password}\n" +
                   "----- Cart -----\n" +
                   $"{cartContent}" +
                   $"----------------\n" +
                   $"Total: {total}kr";
        }

    }
}