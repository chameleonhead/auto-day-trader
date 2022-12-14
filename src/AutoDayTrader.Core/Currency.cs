namespace AutoDayTrader.Core;

public class Currency
{
    public static Currency EUR = new Currency("EUR", 0.0001m);
    public static Currency USD = new Currency("USD", 0.0001m);
    public static Currency JPY = new Currency("JPY", 0.01m);
    public static Currency AUD = new Currency("AUD", 0.0001m);

    private static Dictionary<string, Currency> currencies = new Dictionary<string, Currency>() {
            { EUR.value, EUR},
            { USD.value, USD},
            { JPY.value, JPY},
            { AUD.value, AUD},
        };

    private string value;

    public decimal Pip { get; }

    private Currency(string value, decimal pip)
    {
        this.value = value;
        this.Pip = pip;
    }

    public static Currency Of(string currency)
    {
        if (currencies.TryGetValue(currency, out var value))
        {
            return value;
        }
        throw new ArgumentException("Currency not found.");
    }

    public override string ToString()
    {
        return value;
    }
}
