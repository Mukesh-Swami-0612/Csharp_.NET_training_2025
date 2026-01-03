//Search with Goto: Implement a deep-nested loop search that uses goto to exit all levels instantly upon finding a result.

using System;
class Program
{
    static void Main()
    {
        // 2D array to search in
        int[,] numbers =
        {
            { 10, 20, 30 },
            { 40, 50, 60 },
            { 70, 80, 90 }
        };

        int target = 50;   // Value we want to find
        bool found = false;

        // Outer loop
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            // Inner loop
            for (int j = 0; j < numbers.GetLength(1); j++)
            {
                // Check if current element matches target
                if (numbers[i, j] == target)
                {
                    Console.WriteLine($"Value {target} found at position [{i},{j}]");
                    found = true;

                    // Jump directly to the label and exit all loops
                    goto END_SEARCH;
                }
            }
        }

    // Label where control jumps using goto
    END_SEARCH:

        // Check whether value was found or not
        if (!found)
        {
            Console.WriteLine("Value not found.");
        }
    }
}
