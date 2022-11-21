namespace AutoDayTrader.Core;

public class Quote
{
    public Symbol Symbol { get; }
    public decimal Bid { get; }
    public decimal Ask { get; }

    public Quote(Symbol symbol, decimal bid, decimal ask)
    {
        this.Symbol = symbol;
        this.Bid = bid;
        this.Ask = ask;
    }

    public Spread Spread => Spread.From(Symbol, Bid, Ask);

    public decimal AmountForVolume(Position position, decimal volume)
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
