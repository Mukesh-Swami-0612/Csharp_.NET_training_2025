
Leap Year Checker: Determine if a year is leap (Divisible by 400 OR (Divisible by 4 and NOT 100)).

using System;   // Imports System namespace to use Console class

/// This program checks whether a given year is a leap year or not
class LeapYearChecker
{
    // Main method: program execution starts from here
    static void Main()
    {
        // Ask the user to enter a year
        Console.Write("Enter year: ");

        // Read user input as a string
        string input = Console.ReadLine();

        // TryParse checks whether the input is a valid integer
        // If valid, it stores the value in variable 'y'
        if (int.TryParse(input, out int y))
        {
            // Leap year conditions:
            // 1. Year divisible by 400 → Leap Year
            // 2. OR year divisible by 4 AND not divisible by 100 → Leap Year
            // Otherwise → Not a Leap Year
            Console.WriteLine(
                (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0))
                ? "Leap Year"
                : "Not a Leap Year"
            );
        }
        else
        {
            // This block runs if the input is not a valid number
            Console.WriteLine("Please enter a valid year");
        }
    }
}
