using System;

namespace Github
{
    /// <summary>
    /// This class calculates the area of a circle based on user input for the radius.
    /// </summary>
    class AreaCircle
    {
        // Main method: Entry point of the program
        static void Main()
        {
            #region User Input Section
            // Prompt the user to enter the radius of the circle
            Console.Write("Enter circle radius: ");
            
            // Attempt to parse the input into a double variable for radius
            bool check = double.TryParse(Console.ReadLine(), out double rad);
            #endregion

            #region Validation and Calculation Section
            // Check if the input is valid and the radius is positive
            if (check && rad > 0)
            {
                // Calculate the area of the circle
                double area = Math.PI * rad * rad;
                
                // Output the calculated area
                Console.WriteLine("Area of circle is: {0}", area);
            }
            else
            {
                // Output message for invalid input
                Console.WriteLine("Invalid input");
            }
            #endregion
        }
    }
}
