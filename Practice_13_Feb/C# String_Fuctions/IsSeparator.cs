using System;

class Program
{
    static void Main()
    {
        string s = "Hello\u2028World";

        foreach (char c in s)
        {
            if (char.IsSeparator(c))
                Console.WriteLine("Separator Found");
        }

        string[] parts = s.Split(s.ToCharArray());

        Console.WriteLine("Split Done");
    }
}
