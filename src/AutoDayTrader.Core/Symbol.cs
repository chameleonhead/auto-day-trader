namespace AutoDayTrader.Core;

public interface Symbol
{
    Currency Quoted { get; }
    decimal Pip { get; }
    decimal OrderUnit { get; }

    string ToString();
}
