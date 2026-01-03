
Height Category: Accept height in cm. If < 150 (Dwarf), 150-165 (Average), 165-190 (Tall), >190 (Abnormal)

// Import System namespace to use Console and other basic classes
using System;

// Class to categorize height
public class HeightCategory
{
    // Method that checks height and prints category
    public void CheckHeight(int num)
    {
        // If height is less than 150
        if (num < 150)
        {
            Console.WriteLine("Dwarf");
        }
        // If height is between 150 (inclusive) and 165 (exclusive)
        else if (num >= 150 && num < 165)
        {
            Console.WriteLine("Average");
        }
        // If height is between 165 and 190 (inclusive)
        else if (num >= 165 && num <= 190)
        {
            Console.WriteLine("Tall");
        }
        // If height is greater than 190
        else
        {
            Console.WriteLine("Abnormal");
        }
    }

    // Main method – program execution starts from here
    public static void Main(string[] args)
    {
        // Creating object of HeightCategory class
        HeightCategory pro = new HeightCategory();

        // Asking user to enter height
        Console.WriteLine("Enter height:");

        // Reading input from user as string
        string input = Console.ReadLine();

        // Trying to convert string input into integer
        // If conversion is successful, height value is stored in 'height'
        if (int.TryParse(input, out int height))
        {
            // Calling CheckHeight method with valid integer input
            pro.CheckHeight(height);
        }
        else
        {
            // Executed when input is not a valid integer
            Console.WriteLine("Please enter a valid number");
        }
    }
}

