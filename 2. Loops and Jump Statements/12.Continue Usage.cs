// Problem:
// Print numbers from 1 to 50 but skip multiples of 3

using System;
// Using System namespace for Console output

class ContinueExample
{
    // Program execution starts from Main method
    static void Main()
    {
        // Loop from 1 to 50
        for (int i = 1; i <= 50; i++)
        {
            // If number is divisible by 3
            if (i % 3 == 0)
                continue;
                // continue skips the current iteration
                // and moves to the next value of i

            // This line executes only when i is NOT a multiple of 3
            Console.Write(i + " ");
        }
    }
}
