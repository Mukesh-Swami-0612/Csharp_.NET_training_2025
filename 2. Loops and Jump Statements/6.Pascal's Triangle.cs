
//Pascal's Triangle: Use Nested Loops to print Pascal's triangle up to N rows.

  using System;

class PascalsTriangle
{
    static void Main()
    {
        int n = 5; // Number of rows to print

        // Outer loop for each row
        for (int i = 0; i < n; i++)
        {
            int value = 1; // First value in every row is 1

            // Print spaces to align the triangle
            for (int space = 0; space < n - i - 1; space++)
            {
                Console.Write(" ");
            }

            // Inner loop to print values in each row
            for (int j = 0; j <= i; j++)
            {
                Console.Write(value + " ");

                // Calculate next value using formula
                value = value * (i - j) / (j + 1);
            }

            // Move to next line after each row
            Console.WriteLine();
        }
    }
}
