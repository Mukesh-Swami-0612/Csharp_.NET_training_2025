
// Question:
// Check if given date is valid (handle leap year)

using System;

class ValidDate
{
    static void Main()
    {
        Console.Write("Enter day: ");
        int d = int.Parse(Console.ReadLine());

        Console.Write("Enter month: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Enter year: ");
        int y = int.Parse(Console.ReadLine());

        bool leap = (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0));
        bool valid = true;

        if (m < 1 || m > 12)
            valid = false;
        else if (d < 1)
            valid = false;
        else if (m == 2)
            valid = leap ? d <= 29 : d <= 28;
        else if (m == 4 || m == 6 || m == 9 || m == 11)
            valid = d <= 30;
        else
            valid = d <= 31;

        Console.WriteLine(valid ? "Valid Date" : "Invalid Date");
    }
}

