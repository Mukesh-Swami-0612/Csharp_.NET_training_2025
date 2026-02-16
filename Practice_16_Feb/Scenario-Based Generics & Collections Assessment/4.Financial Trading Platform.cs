using System;
using System.Collections.Generic;
using System.Linq;

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; set; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond }
public enum Trend { Upward, Downward, Sideways }


public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> holdings = new();
    private Dictionary<T, decimal> purchasePrices = new();

    public void Buy(T instrument, int quantity, decimal price)
    {
        if (quantity <= 0 || price <= 0)
        {
            Console.WriteLine("Invalid quantity or price");
            return;
        }

        if (!holdings.ContainsKey(instrument))
        {
            holdings[instrument] = 0;
            purchasePrices[instrument] = price;
        }

        holdings[instrument] += quantity;

        Console.WriteLine("Bought successfully.");
    }

    public void Sell(T instrument, int quantity)
    {
        if (!holdings.ContainsKey(instrument) || holdings[instrument] < quantity)
        {
            Console.WriteLine("Not enough quantity.");
            return;
        }

        holdings[instrument] -= quantity;
        Console.WriteLine("Sold successfully.");
    }

    public decimal CalculateTotalValue()
    {
        return holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public void ShowTopPerformer()
    {
        decimal maxReturn = decimal.MinValue;
        T best = default;

        foreach (var item in holdings)
        {
            decimal buy = purchasePrices[item.Key];
            decimal current = item.Key.CurrentPrice;

            decimal returnPercent = ((current - buy) / buy) * 100;

            if (returnPercent > maxReturn)
            {
                maxReturn = returnPercent;
                best = item.Key;
            }
        }

        if (best != null)
            Console.WriteLine($"Top Performer: {best.Symbol} Return: {maxReturn}%");
        else
            Console.WriteLine("No instruments found.");
    }

    public Dictionary<T, int> GetHoldings() => holdings;
}


public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
}


public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<decimal>> history = new();

    public void AddPrice(T instrument, decimal price)
    {
        if (!history.ContainsKey(instrument))
            history[instrument] = new List<decimal>();

        history[instrument].Add(price);
    }

    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (!history.ContainsKey(instrument)) return null;

        var prices = history[instrument].TakeLast(days);

        if (!prices.Any()) return null;

        return prices.Average();
    }

    public Trend DetectTrend(T instrument)
    {
        if (!history.ContainsKey(instrument) || history[instrument].Count < 2)
            return Trend.Sideways;

        var prices = history[instrument];

        if (prices.Last() > prices.First())
            return Trend.Upward;
        else if (prices.Last() < prices.First())
            return Trend.Downward;
        else
            return Trend.Sideways;
    }
}

class Program
{
    static void Main()
    {
        Portfolio<Stock> portfolio = new();
        PriceHistory<Stock> history = new();

        Console.Write("How many instruments to create? ");
        int n = int.Parse(Console.ReadLine());

        List<Stock> market = new();

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter Symbol: ");
            string symbol = Console.ReadLine();

            Console.Write("Enter Current Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Stock stock = new Stock
            {
                Symbol = symbol,
                CurrentPrice = price
            };

            market.Add(stock);
        }

        Console.WriteLine("\n--- BUY PHASE ---");

        foreach (var stock in market)
        {
            Console.Write($"How many quantity of {stock.Symbol} to buy? ");
            int qty = int.Parse(Console.ReadLine());

            portfolio.Buy(stock, qty, stock.CurrentPrice);
        }

        Console.WriteLine("\nTotal Portfolio Value: " + portfolio.CalculateTotalValue());

        Console.WriteLine("\n--- UPDATE PRICES ---");

        foreach (var stock in market)
        {
            Console.Write($"Enter new price for {stock.Symbol}: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            stock.CurrentPrice = newPrice;
            history.AddPrice(stock, newPrice);
        }

        Console.WriteLine("\nUpdated Portfolio Value: " + portfolio.CalculateTotalValue());

        portfolio.ShowTopPerformer();

        Console.WriteLine("\n--- TREND ANALYSIS ---");

        foreach (var stock in market)
        {
            Console.WriteLine($"{stock.Symbol} Trend: {history.DetectTrend(stock)}");
        }

        Console.WriteLine("\n--- SELL PHASE ---");

        foreach (var stock in market)
        {
            Console.Write($"How many quantity of {stock.Symbol} to sell? ");
            int qty = int.Parse(Console.ReadLine());

            portfolio.Sell(stock, qty);
        }

        Console.WriteLine("\nFinal Portfolio Value: " + portfolio.CalculateTotalValue());
    }
}




// How many instruments to create? 2

// Enter Symbol: TCS
// Enter Current Price: 3500

// Enter Symbol: INFY
// Enter Current Price: 1500
