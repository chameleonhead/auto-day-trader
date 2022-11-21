namespace AutoDayTrader.Core;

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
