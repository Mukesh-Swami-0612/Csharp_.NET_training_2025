// Problem: Check whether a number is Even or Odd using a method

using System;

public class Calc
{
    // Method to check even number
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static void Main(string[] args)
    {
        Calc calc = new Calc();

        // Loop to take input 5 times
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();

            // Input validation
            if (int.TryParse(input, out int number))
            {
                Console.WriteLine("Is " + number + " even? " + calc.IsEven(number));
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
