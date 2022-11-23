namespace AutoDayTrader.Core
{
    public class Tick
    {
        public DateTime Timestamp { get; }
        public Symbol Symbol => Quote.Symbol;
        public Quote Quote { get; }

        public Tick(DateTime timestamp, Quote quote)
        {
            this.Timestamp = timestamp;
            this.Quote = quote;

        }
    }
}