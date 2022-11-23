namespace AutoDayTrader.Core;

public class Spread
{
    public decimal Pips { get; }
    public Spread(decimal pips)
    {
        this.Pips = pips;
    }

    public override string ToString()
    {
        return string.Format($"{Pips}");
    }

    public static Spread From(Symbol symbol, decimal bid, decimal ask)
    {
        return new Spread(Math.Round((ask - bid) / symbol.Pip, 2));
    }
}
