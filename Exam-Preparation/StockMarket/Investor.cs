using System.Collections.Generic;
using System.Linq;
using System;

namespace StockMarket
{
    public class Investor
    {

        public List<Stock> Portfolio { get; private set; }
        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public decimal MoneyToInvest { get; private set; }
        public string BrokerName { get; private set; }
        public Investor(string fullName, string email, decimal moneyToInvest, string broker)
        {
            FullName = fullName;
            EmailAddress = email;
            MoneyToInvest = moneyToInvest;
            BrokerName = broker;
            Portfolio = new List<Stock>();
        }
        public int Count
        {
            get { return this.Portfolio.Count; }
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
               this.MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(firm=>firm.CompanyName==companyName))
            {
                return $"{companyName} does not exist.";
            }
            if (Portfolio.Find(firm=>firm.CompanyName==companyName).PricePerShare>sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            Stock companyForSell = Portfolio.Find(firm => firm.CompanyName == companyName);
            Portfolio.Remove(companyForSell);
            this.MoneyToInvest += sellPrice ;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(n => n.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if (!Portfolio.Any())
            {
                return null;
            }

            return Portfolio.OrderByDescending(v => v.MarketCapitalization).FirstOrDefault();
        }
        public string InvestorInformation()
        {
            string result;
            result = $"The investor {FullName} with a broker {BrokerName} has stocks:{ Environment.NewLine}" +String.Join(Environment.NewLine, this.Portfolio);
            return result;
        }
    }
}
