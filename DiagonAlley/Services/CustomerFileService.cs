using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class CustomerFileService
    {

        private static readonly string filePath = "wizards.txt";

        public static void SaveWizards(List<Wizard> wizards)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Wizard w in wizards)
                {
                    writer.WriteLine($"{w.Name},{w.GetPassword()},{w.Role},{w.Level} ");
                }

            }
        }

        public static List<Wizard> LoadWizards()
        {
            var wizards = new List<Wizard>();

            if (!File.Exists(filePath)) return wizards;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim('\uFEFF', ' ', '\t', '\r', '\n');
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');

                    string name = parts[0].Trim();
                    string password = parts[1].Trim();
                    string role = parts[2].Trim();
                    string levelText = parts.Length >= 4 ? parts[3].Trim() : "None";

                    WizardLevel level = Enum.TryParse(levelText, true, out WizardLevel parsedLevel)
                        ? parsedLevel
                        : WizardLevel.Regular;

                    Wizard w = level switch
                    {
                        WizardLevel.Gold => new GoldWizard(name, password, role),
                        WizardLevel.Silver => new SilverWizard(name, password, role),
                        WizardLevel.Bronze => new BronzeWizard(name, password, role),
                        _ => new Wizard(name, password, role)
                    };

                    wizards.Add(w);
                }
            }
            return wizards;
        }
    }
}