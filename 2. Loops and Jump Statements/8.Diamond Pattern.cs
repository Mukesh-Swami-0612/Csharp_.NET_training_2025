
// Problem:
// Print diamond pattern using *

using System;

class DiamondPattern
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        // Upper half
        for (int i = 1; i <= n; i++)
        {
            for (int s = i; s < n; s++)
                Console.Write(" ");

            for (int j = 1; j <= (2 * i - 1); j++)
                Console.Write("*");

            Console.WriteLine();
        }

        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            for (int s = n; s > i; s--)
                Console.Write(" ");

            for (int j = 1; j <= (2 * i - 1); j++)
                Console.Write("*");

            Console.WriteLine();
        }
    }
}
