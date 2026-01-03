// Question:
// Find quadrant of given (x, y) coordinates

using System;
// Using System namespace for Console input/output

class QuadrantFinder
{
    // Program execution starts from Main method
    static void Main()
    {
        // Read x-coordinate from user
        Console.Write("Enter x coordinate: ");
        int x = int.Parse(Console.ReadLine());

        // Read y-coordinate from user
        Console.Write("Enter y coordinate: ");
        int y = int.Parse(Console.ReadLine());

        // If x is positive and y is positive
        if (x > 0 && y > 0)
            Console.WriteLine("First Quadrant");

        // If x is negative and y is positive
        else if (x < 0 && y > 0)
            Console.WriteLine("Second Quadrant");

        // If x is negative and y is negative
        else if (x < 0 && y < 0)
            Console.WriteLine("Third Quadrant");

        // If x is positive and y is negative
        else if (x > 0 && y < 0)
            Console.WriteLine("Fourth Quadrant");

        // If point lies on X-axis, Y-axis, or Origin
        else
            Console.WriteLine("Point lies on Axis");
    }
}
