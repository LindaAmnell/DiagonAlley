using DiagonAlley.Models;

namespace DiagonAlley.Services
{
    public static class CurrencyConverter
    {
        public static double ConvertFromSEK(double amount, Currency toCurrency)
        {

            if (toCurrency == Currency.USD)
                return amount * 0.09;
            else if (toCurrency == Currency.EUR)
                return amount * 0.085;
            else
                return amount;
        }
        public static string GetSymbol(Currency currency)
        {
            if (currency == Currency.SEK)
                return "kr";
            else if (currency == Currency.USD)
                return "$";
            else if (currency == Currency.EUR)
                return "€";
            else
                return "";
        }

        public static string Format(double amount, Currency currency)
        {
            double converted = ConvertFromSEK(amount, currency);
            string symbol = GetSymbol(currency);

            return $"{converted:F2} {symbol}";
        }


    }
}

