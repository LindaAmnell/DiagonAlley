namespace DiagonAlley.Models.Customer
{
    public class BronzeWizard : Wizard
    {
        public BronzeWizard(string name, string password, string role) : base(name, password, role)
        {
            Level = WizardLevel.Bronze;
            Discount = 0.05;
        }
    }
}
