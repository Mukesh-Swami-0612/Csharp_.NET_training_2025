using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> scans = new List<int> {10,20,10,30,20,40};

        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int id in scans)
        {
            if (!seen.Contains(id))
            {
                seen.Add(id);
                result.Add(id);
            }
        }

        Console.WriteLine(string.Join(", ", result));
    }
}
