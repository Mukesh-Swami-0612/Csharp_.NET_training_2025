//Binary to Decimal: Convert a binary number string to decimal without using built-in library functions.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        string binary = "1011"; // Binary input
        int decimalValue = 0;
        int power = 1; // Represents 2^0 initially

        // Loop from last digit to first
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            // Convert character '0' or '1' to integer
            int bit = binary[i] - '0';

            // Add bit * current power of 2
            decimalValue += bit * power;

            // Move to next power of 2
            power *= 2;
        }

        Console.WriteLine("Decimal value is: " + decimalValue);
    }
}
