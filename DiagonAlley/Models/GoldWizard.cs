namespace DiagonAlley.Models
{
    public class GoldWizard : Wizard
    {
        public GoldWizard(string name, string password, string role) : base(name, password, role)
        {
            Level = WizardLevel.Gold;
            Discount = 0.15;

        }
    }
}
