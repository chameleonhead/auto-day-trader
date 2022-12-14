namespace AutoDayTrader.Core.Tests;

[TestClass]
public class CoreTests
{
    [TestMethod]
    public void USDJPYの売買価格からスプレッドを計算する()
    {
        var usd = Currency.USD;
        var jpy = Currency.JPY;
        var usdjpy = new CurrencyPair(usd, jpy);
        var quote = usdjpy.CreateQuote(110.523m, 110.539m);
        Assert.AreEqual(1.6m, quote.Spread.Pips);
    }
}