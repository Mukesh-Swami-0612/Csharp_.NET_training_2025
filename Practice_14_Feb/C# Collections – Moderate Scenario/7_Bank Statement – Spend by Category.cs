using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var txns = new List<(string, decimal)>
        {
            ("Food",-200),
            ("Fuel",-500),
            ("Food",-50),
            ("Salary",1000)
        };

        Dictionary<string, decimal> result = new Dictionary<string, decimal>();

        foreach (var txn in txns)
        {
            if (txn.Item2 < 0)
            {
                decimal amount = Math.Abs(txn.Item2);

                if (result.ContainsKey(txn.Item1))
                    result[txn.Item1] += amount;
                else
                    result[txn.Item1] = amount;
            }
        }

        foreach (var item in result)
            Console.WriteLine(item.Key + " : " + item.Value);
    }
}
