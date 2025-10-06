namespace DiagonAlley.Models
{
    public class SilverWizard : Wizard
    {
        public SilverWizard(string name, string password, string role) : base(name, password, role)
        {
            Level = WizardLevel.Silver;
            Discount = 0.10;
        }
    }
}
