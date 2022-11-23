namespace AutoDayTrader.Core;

public class Price
{
    public Currency Currency { get; }
    public decimal Value { get; }

    public Price(Currency currency, decimal value)
    {
        this.Currency = currency;
        this.Value = value;
    }

    public static Price operator +(Price lhs, Price rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new ArgumentException(nameof(lhs));
        }
        return new Price(lhs.Currency, lhs.Value + rhs.Value);
    }

    public static Price operator -(Price lhs, Price rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new ArgumentException(nameof(lhs));
        }
        return new Price(lhs.Currency, lhs.Value - rhs.Value);
    }

    public static Price operator *(Price lhs, decimal rhs)
    {
        return new Price(lhs.Currency, lhs.Value * rhs);
    }

    public static Price operator *(decimal lhs, Price rhs)
    {
        return new Price(rhs.Currency, lhs * rhs.Value);
    }

    public static decimal operator /(Price lhs, Price rhs)
    {
        if (lhs.Currency != rhs.Currency)
        {
            throw new ArgumentException(nameof(lhs));
        }
        return lhs.Value / rhs.Value;
    }

    public static Price operator /(Price lhs, decimal rhs)
    {
        return new Price(lhs.Currency, lhs.Value / rhs);
    }
}