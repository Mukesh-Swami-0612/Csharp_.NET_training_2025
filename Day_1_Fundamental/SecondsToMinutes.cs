using System;

namespace TimeConversion
{
    /// <summary>
    /// This class converts time from seconds into minutes and remaining seconds.
    /// </summary>
    public class Github
    {
        // Main method: Entry point of the program
        static void Main()
        {
            #region User Input Section
            // Prompt the user to enter time in seconds
            Console.Write("Enter time in seconds: ");
            
            // Attempt to parse the input into an integer variable
            bool check = int.TryParse(Console.ReadLine(), out int seconds);
            #endregion

            #region Validation and Conversion Section
            // Check if the input is valid and non-negative
            if(check && seconds >= 0)
            {
                // Calculate minutes from seconds
                int minute = seconds / 60;
                
                // Calculate remaining seconds
                int remainingSeconds = seconds % 60;
                
                // Display the converted time
                Console.WriteLine("{0} seconds is equal to {1} minutes and {2} seconds", seconds, minute, remainingSeconds);
            }
            else
            {
                // Display error message for invalid input
                Console.WriteLine("Invalid input");
            }
            #endregion
        }
    }
}
