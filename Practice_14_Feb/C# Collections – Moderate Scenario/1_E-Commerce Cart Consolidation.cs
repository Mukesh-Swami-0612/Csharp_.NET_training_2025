using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var scans = new List<(string, int)>
        {
            ("A101",2),
            ("B205",1),
            ("A101",3),
            ("C111",-1)
        };

        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var item in scans)
        {
            if (item.Item2 <= 0)
                continue;

            if (result.ContainsKey(item.Item1))
                result[item.Item1] += item.Item2;
            else
                result[item.Item1] = item.Item2;
        }

        foreach (var pair in result)
            Console.WriteLine(pair.Key + " : " + pair.Value);
    }
}
