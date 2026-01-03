// Question:
// Check if given date is valid (handle leap year)

using System;
// Using System namespace for Console input/output

class ValidDate
{
    // Program execution starts from Main method
    static void Main()
    {
        // Read day from user
        Console.Write("Enter day: ");
        int d = int.Parse(Console.ReadLine());

        // Read month from user
        Console.Write("Enter month: ");
        int m = int.Parse(Console.ReadLine());

        // Read year from user
        Console.Write("Enter year: ");
        int y = int.Parse(Console.ReadLine());

        // Check whether the given year is a leap year
        // Leap year rules:
        // 1. Divisible by 400 OR
        // 2. Divisible by 4 but NOT divisible by 100
        bool leap = (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0));

        // Assume date is valid initially
        bool valid = true;

        // Month must be between 1 and 12
        if (m < 1 || m > 12)
            valid = false;

        // Day cannot be less than 1
        else if (d < 1)
            valid = false;

        // February month handling
        else if (m == 2)
            valid = leap ? d <= 29 : d <= 28;

        // Months having 30 days
        else if (m == 4 || m == 6 || m == 9 || m == 11)
            valid = d <= 30;

        // Remaining months have 31 days
        else
            valid = d <= 31;

        // Print final result
        Console.WriteLine(valid ? "Valid Date" : "Invalid Date");
    }
}
