using System;

namespace AutoDayTrader.Core.Tests;

[TestClass]
public class PositionSizeCalculatorTests
{
    [TestMethod]
    public void 買い注文のロットを計算する_JPYToJPY()
    {
        var account = new Account(Currency.JPY, 1_000_000, 25);
        var market = new MockMarket(symbol => throw new InvalidOperationException());
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("USDJPY").CreateQuote(99.986m, 100m);
        var lotsToOrder = calculator.CalculateLots(Position.Long, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(1m, lotsToOrder);
    }

    [TestMethod]
    public void 買い注文のロットを計算する_USDToJPY()
    {
        var account = new Account(Currency.JPY, 1_000_000, 25);
        var market = new MockMarket(symbol =>
        {
            if (symbol.ToString() != "USDJPY")
            {
                throw new InvalidOperationException();
            }
            return new Tick(DateTime.MinValue, new Quote(symbol, 99.986m, 100m));
        });
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("EURUSD").CreateQuote(1.00016m, 1.00000m);
        var lotsToOrder = calculator.CalculateLots(Position.Long, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(1m, lotsToOrder);
    }

    [TestMethod]
    public void 買い注文のロットを計算する_JPYToUSD()
    {
        var account = new Account(Currency.USD, 1_000_000, 25);
        var market = new MockMarket(symbol =>
        {
            if (symbol.ToString() != "USDJPY")
            {
                throw new InvalidOperationException();
            }
            return new Tick(DateTime.MinValue, new Quote(symbol, 99.986m, 100m));
        });
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("USDJPY").CreateQuote(99.986m, 100m);
        var lotsToOrder = calculator.CalculateLots(Position.Long, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(100m, lotsToOrder);
    }

    [TestMethod]
    public void 売り注文のロットを計算する_JPYToJPY()
    {
        var account = new Account(Currency.JPY, 1_000_000, 25);
        var market = new MockMarket(symbol => throw new InvalidOperationException());
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("USDJPY").CreateQuote(100m, 99.986m);
        var lotsToOrder = calculator.CalculateLots(Position.Short, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(1m, lotsToOrder);
    }

    [TestMethod]
    public void 売り注文のロットを計算する_USDToJPY()
    {
        var account = new Account(Currency.JPY, 1_000_000, 25);
        var market = new MockMarket(symbol =>
        {
            if (symbol.ToString() != "USDJPY")
            {
                throw new InvalidOperationException();
            }
            return new Tick(DateTime.MinValue, new Quote(symbol, 100m, 99.986m));
        });
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("EURUSD").CreateQuote(1.00000m, 0.99986m);
        var lotsToOrder = calculator.CalculateLots(Position.Short, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(1m, lotsToOrder);
    }

    [TestMethod]
    public void 売り注文のロットを計算する_JPYToUSD()
    {
        var account = new Account(Currency.USD, 1_000_000, 25);
        var market = new MockMarket(symbol =>
        {
            if (symbol.ToString() != "USDJPY")
            {
                throw new InvalidOperationException();
            }
            return new Tick(DateTime.MinValue, new Quote(symbol, 100m, 99.986m));
        });
        var calculator = new PositionSizeCalculator(new TradingContext(account, market));
        var quote = new CurrencyPair("USDJPY").CreateQuote(100m, 99.986m);
        var lotsToOrder = calculator.CalculateLots(Position.Short, quote, 30, account.Capital * 0.03m);
        Assert.AreEqual(100m, lotsToOrder);
    }
}