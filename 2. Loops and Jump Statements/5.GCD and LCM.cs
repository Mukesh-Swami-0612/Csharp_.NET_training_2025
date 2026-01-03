// Problem:
// Find GCD and LCM of two numbers

using System;

class GcdLcm
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int x = a, y = b;

        // Find GCD using Euclidean method
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }

        int gcd = x;
        int lcm = (a * b) / gcd;

        Console.WriteLine("GCD = " + gcd);
        Console.WriteLine("LCM = " + lcm);
    }
}

