namespace DiagonAlley.Models
{
    public class Potion : Product
    {
        public string Effect { get; private set; }
        public int Duration { get; private set; }

        public Potion(string name, double price, int amount, string effect, int duration) : base(name, price, amount)
        {
            Effect = effect;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Name,-18} | {Effect,-16} | {Duration,6} min | {GetFormattedPrice(),12} |";
        }

    }
}
