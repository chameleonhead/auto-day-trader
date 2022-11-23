namespace AutoDayTrader.Core;

public class RiskCalculator
{
    private TradingContext context;

    public RiskCalculator(TradingContext context)
    {
        this.context = context;
    }

    public decimal CalculateLots(Position position, Quote quote, decimal targetPips, decimal percentageOfRiskAgainstCapital)
    {
        var acceptedRiskAmountInAccountCurrency = context.Account.Capital * percentageOfRiskAgainstCapital / 100;
        var acceptedRiskAmountInQuotedCurrency = context.Convert(acceptedRiskAmountInAccountCurrency, quote.Symbol.Quoted, position);
        var valueForTargetPipInVolume = quote.AmountForVolume(position, targetPips * quote.Symbol.Pip);
        return acceptedRiskAmountInQuotedCurrency * (position == Position.Long ? quote.Ask.Value : quote.Bid.Value) / valueForTargetPipInVolume;
    }
}