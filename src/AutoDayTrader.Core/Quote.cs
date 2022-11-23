namespace AutoDayTrader.Core;

public class Quote
{
    public Symbol Symbol { get; }
    public Price Bid { get; }
    public Price Ask { get; }

    public Quote(Symbol symbol, decimal bid, decimal ask)
    {
        this.Symbol = symbol;
        this.Bid = new Price(symbol.Quoted, bid);
        this.Ask = new Price(symbol.Quoted, ask);
    }

    public Spread Spread => Spread.From(Symbol, Bid.Value, Ask.Value);

    public Price AmountForVolume(Position position, decimal volume)
    {
        switch (position)
        {
            case Position.Long:
                return Symbol.OrderUnit * Ask * volume;
            case Position.Short:
                return Symbol.OrderUnit * Bid * volume;
            default:
                throw new ArgumentException(nameof(position));
        }
    }
}
