using System;

class Program
{
    static void Main()
    {
        string s = "Ⅻ45";

        int count = 0;

        foreach (char c in s)
        {
            if (char.IsNumber(c))
                count++;
        }

        Console.WriteLine("Numeric Count: " + count);
    }
}
