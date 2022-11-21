namespace AutoDayTrader.Core.Tests;

[TestClass]
public class RiskManagementTests
{
    [TestMethod]
    public void 注文ロットを計算する()
    {
        var account = new Account(Currency.JPY, 10_000_000, 25);
        var calculator = new RiskCalculator(account);
        var quote = new CurrencyPair("USDJPY").CreateQuote(99.986m, 100m);
        var lotsToOrder = calculator.CalculateLots(Position.Long, quote, 30, 3);
        Assert.AreEqual(3, lotsToOrder);
    }
}