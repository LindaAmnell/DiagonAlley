namespace DiagonAlley.Models
{
    public class Wizard
    {
        public string Name { get; private set; }
        private string Password { get; set; }
        public string Role { get; private set; }

        private List<Product> cart;

        public List<Product> Cart
        {
            get { return cart; }
        }

        public Wizard(string name, string password, string role)
        {
            Name = name;
            Password = password;
            cart = new List<Product>();
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

        public override string ToString()
        {

            if (cart.Count == 0)
                return $"Name: {Name} | Password: {Password} | Cart: Empty";

            string cartContent = "";
            double total = 0;

            foreach (Product p in cart)
            {
                double productTotal = p.TotalPrice();
                cartContent += $"{p.Amount}kr x {p.Name} = {productTotal}kr\n";
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