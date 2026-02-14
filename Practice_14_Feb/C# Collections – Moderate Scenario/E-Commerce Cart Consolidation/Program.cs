using System;
using System.Collections.Generic;

public class Program
{
    public static Dictionary<string, int> ConsolidateCart(List<(string sku, int qty)> scans)
    {
        var result = new Dictionary<string, int>();

        foreach (var item in scans)
        {
            if (item.qty <= 0)
                continue;

            if (result.ContainsKey(item.sku))
                result[item.sku] += item.qty;
            else
                result[item.sku] = item.qty;
        }

        return result;
    }
}
