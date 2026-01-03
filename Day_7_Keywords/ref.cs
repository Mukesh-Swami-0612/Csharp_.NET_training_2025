using System;

// This class contains a method that uses ref parameters
public class Reference
{
    // Method that accepts parameters by reference
    // ref means the original variables will be modified
    public int Referencing(ref int x, ref int y)
    {
        // Increase x by 1 (original variable will change)
        x = x + 1;

        // Increase y by 1 (original variable will change)
        y = y + 1;

        // Return the sum of modified values
        return x + y;
    }
}

// Main class
public class Ref
{
    public static void Main(string[] args)
    {
        // Creating object of Reference class
        Reference r1 = new Reference();

        // Initial values
        int a = 10;
        int b = 4;

        // Calling method using ref keyword
        // a and b are passed by reference
        int result = r1.Referencing(ref a, ref b);

        // Printing returned result
        Console.WriteLine("Result: " + result);

        // a is changed because ref was used
        Console.WriteLine("a after method call: " + a);

        // b is also changed because ref was used
        Console.WriteLine("b after method call: " + b);
    }
}
