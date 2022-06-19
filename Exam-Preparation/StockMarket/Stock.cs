using System;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; private set; }
        public string Director { get; private set; }
        public decimal PricePerShare { get; private set; }
        public int TotalNumberOfShares { get; private set; }
        public decimal MarketCapitalization { get { return this.PricePerShare * this.TotalNumberOfShares; } set { value = this.MarketCapitalization; } }

        public Stock(string name, string director, decimal pricePerShare, int totalNumOfShares)
        {
            CompanyName = name;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumOfShares;
            MarketCapitalization = pricePerShare * totalNumOfShares;
        }
        public override string ToString()
        {
            string result = $"Company: {this.CompanyName}{Environment.NewLine}" +
                            $"Director: {this.Director}{Environment.NewLine}" +
                            $"Price per share: ${this.PricePerShare:f2}{Environment.NewLine}" +
                            $"Market capitalization: ${this.MarketCapitalization:f2}".TrimEnd().TrimStart();
            return result;
        }
    }
}
