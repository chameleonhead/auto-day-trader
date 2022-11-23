namespace AutoDayTrader.Core
{
    public class Tick
    {
        public DateTime Timestamp { get; }
        public Symbol Symbol { get; }
        public Quote Quote { get; }

        public Tick(DateTime timestamp, Symbol symbol, Quote quote)
        {
            this.Timestamp = timestamp;
            this.Symbol = symbol;
            this.Quote = quote;

        }

    }
}