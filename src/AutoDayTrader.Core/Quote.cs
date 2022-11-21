namespace AutoDayTrader.Core;

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
