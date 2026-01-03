using System;

// This class demonstrates use of out parameters
public class Multi
{
    // Method that returns multiple values using out parameters
    // out parameters do not need to be initialized before passing
    public int MultiValue(int n, out int square, out int half, out int addBy3)
    {
        // Calculating square of the number
        square = n * n;

        // Calculating half of the number
        half = n / 2;

        // Adding 3 to the number
        addBy3 = n + 3;

        // Returning the original value
        return n;
    }
}

// Main class
public class Program
{
    public static void Main(string[] args)
    {
        // Creating object of Multi class
        Multi m1 = new Multi();

        // Input value
        int n = 10;

        // Declaring variables for out parameters
        // Initialization is NOT required for out variables
        int square, half, addBy3;

        // Calling method with out keyword
        int original = m1.MultiValue(n, out square, out half, out addBy3);

        // Printing all values
        Console.WriteLine(
            $"Original: {original}, Square: {square}, Half: {half}, AddBy3: {addBy3}"
        );
    }
}
