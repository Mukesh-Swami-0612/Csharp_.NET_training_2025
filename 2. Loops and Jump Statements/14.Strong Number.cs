// Problem:
// Check if number is a Strong number
// Strong number example: 145 = 1! + 4! + 5!

using System;

class StrongNumber
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        int temp = num;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            int fact = 1;

            for (int i = 1; i <= digit; i++)
                fact *= i;

            sum += fact;
            temp /= 10;
        }

        if (sum == num)
            Console.WriteLine("Strong Number");
        else
            Console.WriteLine("Not a Strong Number");
    }
}

