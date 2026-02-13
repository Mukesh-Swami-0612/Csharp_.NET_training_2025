using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string s = "Hello   World \n\t Test";

        int count = 0;

        foreach (char c in s)
        {
            if (char.IsWhiteSpace(c))
                count++;
        }

        string normalized = Regex.Replace(s, @"\s+", " ");

        Console.WriteLine("Whitespace Count: " + count);
        Console.WriteLine("Normalized: " + normalized);
    }
}
