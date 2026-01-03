// Problem:
// Check if number is a Strong number
// Strong number example: 145 = 1! + 4! + 5!

using System;
// Using System namespace for Console input/output

class StrongNumber
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter a number
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        // Store original number for comparison
        int temp = num;

        // Variable to store sum of factorials of digits
        int sum = 0;

        // Loop through each digit of the number
        while (temp > 0)
        {
            // Extract last digit
            int digit = temp % 10;

            // Calculate factorial of the digit
            int fact = 1;

            // Factorial calculation loop
            for (int i = 1; i <= digit; i++)
                fact *= i;

            // Add factorial to sum
            sum += fact;

            // Remove last digit
            temp /= 10;
        }

        // Compare sum of factorials with original number
        if (sum == num)
            Console.WriteLine("Strong Number");
        else
            Console.WriteLine("Not a Strong Number");
    }
}
