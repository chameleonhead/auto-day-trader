namespace AutoDayTrader.Core;

public class Account
{
    public Currency Currency { get; }
    public decimal Capital { get; }
    public decimal MaximumLeverage { get; }

    public Account(Currency currency, decimal capital, decimal maximumLeverage)
    {
        this.Currency = currency;
        this.Capital = capital;
        this.MaximumLeverage = maximumLeverage;
    }
}