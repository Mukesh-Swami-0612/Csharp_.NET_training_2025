using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> serials = new List<string>
        {"S1","S2","S1","S3","S2","S2"};

        HashSet<string> seen = new HashSet<string>();
        HashSet<string> added = new HashSet<string>();
        List<string> duplicates = new List<string>();

        foreach (string s in serials)
        {
            if (!seen.Add(s))
            {
                if (!added.Contains(s))
                {
                    duplicates.Add(s);
                    added.Add(s);
                }
            }
        }

        Console.WriteLine(string.Join(", ", duplicates));
    }
}
