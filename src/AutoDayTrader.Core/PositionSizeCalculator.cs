namespace AutoDayTrader.Core;

public class PositionSizeCalculator
{
    private TradingContext context;

    public PositionSizeCalculator(TradingContext context)
    {
        this.context = context;
    }

    public decimal CalculateLots(Position position, Quote quote, decimal targetPips, Price riskAmount)
    {
        var riskAmountInQuotedCurrency = context.Convert(riskAmount, quote.Symbol.Quoted, position);
        var valueForTargetPipInVolume = quote.AmountForVolume(position, targetPips * quote.Symbol.Pip);
        return riskAmountInQuotedCurrency * quote.PriceForPosition(position).Value / valueForTargetPipInVolume;
    }
}