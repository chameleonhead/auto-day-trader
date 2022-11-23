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
        var targetQuote = tick.Quote;
        if (currencyPair.Key.Equals(value.Currency))
        {
            return new Price(target, position == Position.Long ? value.Value * targetQuote.Ask.Value : value.Value * targetQuote.Bid.Value);
        }
        else
        {
            return new Price(target, position == Position.Long ? value.Value / targetQuote.Ask.Value : value.Value / targetQuote.Bid.Value);
        }
    }
}