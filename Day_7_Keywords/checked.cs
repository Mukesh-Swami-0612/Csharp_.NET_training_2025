using System;

// This class contains methods for addition
public class AddTwo
{
    // Normal addition method
    // This does NOT check for integer overflow
    public int Add(int a, int b)
    {
        int c = a + b;   // Overflow may occur here
        return c;
    }

    // Addition using checked block
    // This WILL throw an exception if overflow happens
    public int AddChecked(int a, int b)
    {
        checked
        {
            int c = a + b;   // OverflowException if result exceeds int range
            return c;
        }
    }
}

// Main class
public class MaxValue
{
    public static void Main(string[] args)
    {
        // int.MaxValue is the maximum value an int can store
        int x = int.MaxValue;
        int y = 1;

        // Printing maximum int value
        Console.WriteLine(x);

        // Creating object of AddTwo class
        AddTwo a1 = new AddTwo();

        // Normal addition (overflow happens silently)
        int sum = a1.Add(x, y);
        Console.WriteLine(sum);   // Result becomes negative due to overflow

        Console.WriteLine("After Checked:");

        try
        {
            // Checked addition (throws exception)
            int sumChecked = a1.AddChecked(x, y);
            Console.WriteLine(sumChecked);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow occurred!");
        }
    }
}
