namespace AutoDayTrader.Web;

public interface Symbol
{
    double Pip { get; }
    string ToString();
}

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

public class CurrencyPair : Symbol
{
    public Currency Key { get; }
    public Currency Quoted { get; }
    public double Pip => Quoted.Pip;

    public CurrencyPair(Currency key, Currency quoted)
    {
        if (key.Equals(quoted))
        {
            throw new ArgumentException(nameof(quoted));
        }
        this.Key = key;
        this.Quoted = quoted;
    }

    public CurrencyPair(string symbol)
    {
        if (symbol == null)
        {
            throw new ArgumentNullException(nameof(symbol));
        }
        if (symbol.Length != 6)
        {
            throw new ArgumentException(nameof(symbol));
        }
        Key = Currency.Of(symbol.Substring(0, 3));
        Quoted = Currency.Of(symbol.Substring(3));
    }

    public override string ToString()
    {
        return Key.ToString() + Quoted.ToString();
    }

    public Quote CreateQuote(double bid, double ask)
    {
        return new Quote(this, bid, ask);
    }
}

public enum Position
{
    Long = 1,
    Short = 2,
}

public class Spread
{
    public double Pips { get; }
    public Spread(double pips)
    {
        this.Pips = pips;
    }
    public static Spread From(Symbol symbol, double bid, double ask)
    {
        return new Spread(Math.Round((ask - bid) / symbol.Pip, 2));
    }
}

public class Quote
{
    public Symbol Symbol { get; }
    public double Ask { get; }
    public double Bid { get; }

    public Quote(Symbol symbol, double ask, double bid)
    {
        this.Symbol = symbol;
        this.Ask = ask;
        this.Bid = bid;
    }

    public Spread Spread => Spread.From(Symbol, Ask, Bid);
}
