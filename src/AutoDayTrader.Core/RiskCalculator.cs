namespace AutoDayTrader.Core;

public class RiskCalculator
{
    public Account Account { get; }

    public RiskCalculator(Account account)
    {
        this.Account = account;
    }

    public decimal CalculateLots(Position position, Quote quote, decimal targetPips, decimal percentageOfRiskAgainstCapital)
    {
        var acceptedAmount = Account.Capital * percentageOfRiskAgainstCapital / 100;
        var valueForTargetPips = quote.AmountForVolume(position, quote.Symbol.Pip);
        return acceptedAmount / valueForTargetPips;
    }


}