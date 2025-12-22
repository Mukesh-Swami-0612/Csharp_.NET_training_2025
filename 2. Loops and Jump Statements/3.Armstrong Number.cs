
// Problem:
// Check if a number is an Armstrong number
// Armstrong number example: 153 = 1³ + 5³ + 3³

using System;

class ArmstrongNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        int temp = num;   // Store original number
        int sum = 0;

        // Count number of digits
        int digits = num.ToString().Length;

        // Extract digits and calculate power sum
        while (temp > 0)
        {
            int digit = temp % 10;
            sum += (int)Math.Pow(digit, digits);
            temp /= 10;
        }

        if (sum == num)
            Console.WriteLine("Armstrong Number");
        else
            Console.WriteLine("Not an Armstrong Number");
    }
}
