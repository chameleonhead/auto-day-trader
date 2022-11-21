namespace AutoDayTrader.Core;

public class Currency
{
    public static Currency EUR = new Currency("EUR", 0.0001);
    public static Currency USD = new Currency("USD", 0.0001);
    public static Currency JPY = new Currency("JPY", 0.01);
    public static Currency AUD = new Currency("AUD", 0.0001);

    private static Dictionary<string, Currency> currencies = new Dictionary<string, Currency>() {
            { EUR.value, EUR},
            { USD.value, USD},
            { JPY.value, JPY},
            { AUD.value, AUD},
        };

    private string value;

    public double Pip { get; }

    private Currency(string value, double pip)
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
