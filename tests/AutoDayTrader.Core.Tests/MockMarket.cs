using System;

namespace AutoDayTrader.Core.Tests;


public class MockMarket : IMarket
{
    private Func<Symbol, Tick> handler;

    public MockMarket(Func<Symbol, Tick> handler)
    {
        this.handler = handler;
    }

    public Tick CurrentTickForSymbol(Symbol symbol)
    {
        return handler(symbol);
    }
}