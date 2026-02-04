
using System;

class InputHandler
{
    static void Main()
    {
        int number;
        bool isValid = false;

        while (!isValid)
        {
            try
            {
                // Read input from user
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                // Convert to integer
                number = int.Parse(input);

                // If conversion successful
                isValid = true;

                Console.WriteLine("You entered: " + number);
            }
            catch (FormatException)
            {
                // Handles non-numeric input
                Console.WriteLine("Invalid input! Please enter numbers only.");
            }
            catch (OverflowException)
            {
                // Handles very large numbers
                Console.WriteLine("Number is too large or too small.");
            }
            catch (Exception ex)
            {
                // Handles any other error
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.ReadLine();
    }
}
