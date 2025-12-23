// Question:
// Check if triangle is Equilateral, Isosceles, or Scalene

using System;
// Using System namespace for Console input/output

class TriangleType
{
    // Program execution starts from Main method
    static void Main()
    {
        // Read first side of triangle
        Console.Write("Enter side 1: ");
        int a = int.Parse(Console.ReadLine());

        // Read second side of triangle
        Console.Write("Enter side 2: ");
        int b = int.Parse(Console.ReadLine());

        // Read third side of triangle
        Console.Write("Enter side 3: ");
        int c = int.Parse(Console.ReadLine());

        // All three sides are equal → Equilateral triangle
        if (a == b && b == c)
        {
            Console.WriteLine("Equilateral Triangle");
        }
        // Any two sides are equal → Isosceles triangle
        else if (a == b || b == c || a == c)
        {
            Console.WriteLine("Isosceles Triangle");
        }
        // All sides are different → Scalene triangle
        else
        {
            Console.WriteLine("Scalene Triangle");
        }
    }
}
