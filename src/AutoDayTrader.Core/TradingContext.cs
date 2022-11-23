namespace AutoDayTrader.Core;

public class TradingContext
{
    public Account Account { get; }
    public IMarket Market { get; }
    public TradingContext(Account account, IMarket market)
    {
        this.Account = account;
        this.Market = market;
    }

    public Price Convert(Price value, Currency target, Position position)
    {
        if (value.Currency == target)
        {
            return value;
        }

        var currencyPair = CurrencyPair.Of(value.Currency, target);
        var tick = Market.CurrentTickForSymbol(currencyPair);
        var price = tick.Quote.PriceForPosition(position);
        if (currencyPair.Key.Equals(value.Currency))
        {
            return new Price(target, value.Value * price.Value);
        }
        else
        {
            return new Price(target, value.Value / price.Value);
        }
    }
}