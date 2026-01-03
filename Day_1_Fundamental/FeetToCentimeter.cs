using System;

namespace Github
{
    /// <summary>
    /// This class converts a length in feet to centimeters.
    /// </summary>
    public class FeetToCentimeter
    {
        // Main method: Entry point of the program
        static void Main()
        {
            #region User Input Section
            // Prompt the user to enter a length in feet
            Console.Write("Enter length in feet: ");
            
            // Attempt to parse the input into a double variable for feet
            bool check = double.TryParse(Console.ReadLine(), out double feet);
            #endregion

            #region Validation and Conversion Section
            // Check if the input is valid and the feet value is non-negative
            if(check && feet >= 0)
            {
                // Convert the length from feet to centimeters (1 foot = 30.48 cm)
                double centimeters = feet * 30.48;
                
                // Output the conversion result
                Console.WriteLine("{0} feet is equal to {1} centimeters", feet, centimeters);
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
