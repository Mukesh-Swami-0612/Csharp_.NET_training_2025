using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> codes = new List<string>
        {"E02","E01","E02","E01","E03"};

        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach (string code in codes)
        {
            if (freq.ContainsKey(code))
                freq[code]++;
            else
                freq[code] = 1;
        }

        string result = "";
        int max = 0;

        foreach (var pair in freq)
        {
            if (pair.Value > max ||
               (pair.Value == max && pair.Key.CompareTo(result) < 0))
            {
                max = pair.Value;
                result = pair.Key;
            }
        }

        Console.WriteLine(result);
    }
}
