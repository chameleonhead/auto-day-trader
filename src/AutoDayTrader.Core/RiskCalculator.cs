namespace AutoDayTrader.Core;

public class RiskCalculator
{
    public Account Account { get; }
    public IMarket Market { get; }

    public RiskCalculator(Account account, IMarket market)
    {
        this.Account = account;
        this.Market = market;
    }

    public decimal CalculateLots(Position position, Quote quote, decimal targetPips, decimal percentageOfRiskAgainstCapital)
    {
        var acceptedAmount = Account.Capital * percentageOfRiskAgainstCapital / 100;
        var valueForAVolume = quote.AmountForVolume(position, 1);
        var targetCurrency = quote.Symbol.Quoted;
        if (!quote.Symbol.Quoted.Equals(Account.Currency))
        {
            var currencyPair = CurrencyPair.Of(quote.Symbol.Quoted, Account.Currency);
            var tick = Market.CurrentTickForSymbol(currencyPair);
            var targetQuote = tick.Quote;
            if (currencyPair.Key.Equals(quote.Symbol.Quoted))
            {
                var exchangedRate = position == Position.Long ? quote.Ask * targetQuote.Ask : quote.Bid * targetQuote.Bid;
                valueForAVolume *= exchangedRate;
                targetCurrency = currencyPair.Quoted;
            }
            else
            {
                var exchangedRate = position == Position.Long ? quote.Ask / targetQuote.Ask : quote.Bid / targetQuote.Bid;
                valueForAVolume *= exchangedRate;
                targetCurrency = currencyPair.Key;
            }
        }
        return acceptedAmount / (valueForAVolume * targetCurrency.Pip * targetPips);
    }
}