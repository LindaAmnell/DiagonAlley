using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class DataService
    {

        private static List<Product> productList = new List<Product>

        {   new Wand("Elder Wand", 9999, 0, "Thestral hair", 15),
            new Wand("Holly Wand", 3000, 0, "Phoenix feather", 11),
            new Wand("Yew Wand", 4500, 0, "Dragon heartstring", 13),

            new Potion("Polyjuice Potion", 500, 0, "Transformation", 60),
            new Potion("Felix Felicis", 1200, 0, "Luck Boost", 30),
            new Potion("Amortentia", 800, 0, "Love Effect", 45),

            new Broomstick("Firebolt", 1500, 0, 200, "Nimbus Racing Brooms Ltd."),
            new Broomstick("Nimbus 2000", 1000, 0, 150, "Nimbus Racing Brooms Ltd."),
            new Broomstick("Cleansweep Seven", 700, 0, 120, "Cleansweep Co.")
        };

        private static List<Wizard> wizards = CustomerFileService.LoadWizards();

        public static List<T> GetProductByType<T>() where T : Product
        {
            return productList.OfType<T>().ToList();
        }

        public static List<Wizard> GetAllWizards()
        {
            return wizards;
        }

        public static void AddWizard(Wizard w)
        {
            wizards.Add(w);
            CustomerFileService.SaveWizards(wizards);
        }
    }
}
