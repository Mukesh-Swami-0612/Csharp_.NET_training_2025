// Problem:
// Display the first N terms of the Fibonacci series
// Fibonacci series: 0 1 1 2 3 5 8 ...

using System;

class FibonacciSeries
{
    // Main method: program execution starts here
    static void Main()
    {
        // Ask user for number of terms
        Console.Write("Enter number of terms: ");
        int n = int.Parse(Console.ReadLine());

        // First two Fibonacci numbers
        int a = 0, b = 1;

        Console.WriteLine("Fibonacci Series:");

        // Loop to print Fibonacci numbers
        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");

            // Calculate next number
            int next = a + b;
            a = b;
            b = next;
        }
    }
}

