namespace AutoDayTrader.Core;

public interface Symbol
{
    double Pip { get; }
    string ToString();
}
