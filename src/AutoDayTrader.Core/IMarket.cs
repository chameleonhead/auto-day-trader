namespace AutoDayTrader.Core;

public interface IMarket
{
    Tick CurrentTickForSymbol(Symbol symbol);
}