Largest of Three: Take three integers and find the maximum using nested if.


using System;   // Imports System namespace to use Console class

class LargestOfThree
{
    // Main method: program execution starts from here
    // This program takes three numbers from the user
    // and finds the largest number among them
    public static void Main()
    {
        // Ask the user to enter the first number
        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine());
        // Console.ReadLine() reads input as string
        // int.Parse() converts string input into integer

        // Ask the user to enter the second number
        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine());

        // Ask the user to enter the third number
        Console.WriteLine("Enter third number:");
        int c = int.Parse(Console.ReadLine());

        // Check if the first number is greater than the second number
        if (a > b)
        {
            // If a is greater than b, now check if a is greater than c
            if (a > c)
            {
                // a is the largest number
                Console.WriteLine("Largest number is: " + a);
            }
            else
            {
                // c is greater than a
                Console.WriteLine("Largest number is: " + c);
            }
        }
        else
        {
            // If a is not greater than b, then b is greater or equal to a
            // Now check if b is greater than c
            if (b > c)
            {
                // b is the largest number
                Console.WriteLine("Largest number is: " + b);
            }
            else
            {
                // c is the largest number
                Console.WriteLine("Largest number is: " + c);
            }
        }
    }
}
