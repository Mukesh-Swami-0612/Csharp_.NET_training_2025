// Problem:
// Repeatedly sum digits until single digit is obtained

using System;
// Using System namespace for Console input/output

class DigitalRoot
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter a number
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        // Outer loop:
        // Runs until the number becomes a single digit
        while (num >= 10)
        {
            // Variable to store sum of digits
            int sum = 0;

            // Inner loop:
            // Extracts and adds each digit of the number
            while (num > 0)
            {
                sum += num % 10; // Get last digit and add to sum
                num /= 10;       // Remove last digit
            }

            // Assign sum back to num for next iteration
            num = sum;
        }

        // Print the final single digit (digital root)
        Console.WriteLine("Digital Root = " + num);
    }
}
