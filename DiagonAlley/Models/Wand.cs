namespace DiagonAlley.Models
{
    public class Wand : Product
    {
        public String Core { get; private set; }
        public double Length { get; private set; }



        public Wand(string name, double price, int amount, string core, double length) : base(name, price, amount)
        {

            Core = core;
            Length = length;

        }

        public string Info()
        {
            return $"{Name} Core: {Core}, Length: {Length} - {Price} kr ";
        }
    }
}
