// Question:
// Vowel or Consonant using switch statement

using System;
// Using System namespace for Console input/output

class VowelCheck
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter a character
        Console.Write("Enter a character: ");

        // Read input, take first character, convert to lowercase
        // This avoids issues with uppercase vowels
        char ch = char.ToLower(Console.ReadLine()[0]);

        // Switch statement to check vowel
        switch (ch)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                // If character matches any vowel
                Console.WriteLine("Vowel");
                break;

            default:
                // Any other character is treated as consonant
                Console.WriteLine("Consonant");
                break;
        }
    }
}
