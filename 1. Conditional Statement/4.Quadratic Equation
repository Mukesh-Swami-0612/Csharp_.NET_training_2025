
Quadratic Equation: Calculate roots of $ax^2 + bx + c = 0$ using if-else to check the discriminant.

using System;   // Imports System namespace to use Console and Math classes

// This program calculates the roots of a quadratic equation
// Equation format: ax² + bx + c = 0
class QuadraticEquation
{
    // Main method: program execution starts here
    static void Main()
    {
        // Ask the user to enter value of a
        Console.Write("Enter value of a: ");
        double a = double.Parse(Console.ReadLine());
        // double is used because roots can be decimal

        // Ask the user to enter value of b
        Console.Write("Enter value of b: ");
        double b = double.Parse(Console.ReadLine());

        // Ask the user to enter value of c
        Console.Write("Enter value of c: ");
        double c = double.Parse(Console.ReadLine());

        // Calculate the discriminant (D = b² - 4ac)
        double D = b * b - 4 * a * c;

        // If discriminant is greater than 0
        // then roots are real and different
        if (D > 0)
        {
            // Calculate two different real roots
            double root1 = (-b + Math.Sqrt(D)) / (2 * a);
            double root2 = (-b - Math.Sqrt(D)) / (2 * a);

            Console.WriteLine("Roots are real and different");
            Console.WriteLine("Root 1 = " + root1);
            Console.WriteLine("Root 2 = " + root2);
        }
        // If discriminant is equal to 0
        // then roots are real and equal
        else if (D == 0)
        {
            // Calculate the single root
            double root = -b / (2 * a);

            Console.WriteLine("Roots are real and equal");
            Console.WriteLine("Root = " + root);
        }
        // If discriminant is less than 0
        // then roots are imaginary (not real)
        else
        {
            Console.WriteLine("Roots are imaginary (no real roots)");
        }
    }
}

