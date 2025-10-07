using DiagonAlley.UI;

namespace DiagonAlley.Models
{
    public class Broomstick : Product
    {
        public int Speed { get; private set; }
        public string Model { get; private set; }
        public Broomstick(string name, double price, int amount, int speed, string model) : base(name, price, amount)
        {
            Speed = speed;
            Model = model;

        }
        public override string ToString()
        {
            return $"{Name} | Speed: {Speed} km/h | Brand: {Model} | {GetFormattedPrice(StoreController.SelectedCurrency)}";
        }

    }
}
