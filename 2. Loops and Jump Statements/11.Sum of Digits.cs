// Problem:
// Repeatedly sum digits until single digit is obtained

using System;

class DigitalRoot
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        while (num >= 10)
        {
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            num = sum;
        }

        Console.WriteLine("Digital Root = " + num);
    }
}

