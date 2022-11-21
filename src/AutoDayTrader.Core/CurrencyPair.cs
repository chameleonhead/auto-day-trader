namespace AutoDayTrader.Core;

public class CurrencyPair : Symbol
{
    public Currency Key { get; }
    public Currency Quoted { get; }
    public decimal Pip => Quoted.Pip;
    public decimal OrderUnit => 100_000;

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

    public Quote CreateQuote(decimal bid, decimal ask)
    {
        return new Quote(this, bid, ask);
    }
}
