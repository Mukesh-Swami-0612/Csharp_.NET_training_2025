using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string s = "AB12C03Z9";

        // Count digits
        int count = 0;

        // Extract digits
        List<int> digits = new List<int>();

        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                count++;
                digits.Add(c - '0');
            }
        }

        Console.WriteLine("Digit Count: " + count);
        Console.WriteLine("Digits: " + string.Join(",", digits));
    }
}
