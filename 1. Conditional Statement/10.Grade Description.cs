// Question:
// Input grade (E, V, G, A, F) and print description

using System;
// Using System namespace for Console input/output

class GradeDescription
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter grade
        Console.Write("Enter grade (E/V/G/A/F): ");

        // Read input, take first character, convert it to uppercase
        // This avoids issues if user enters lowercase letters
        char grade = char.ToUpper(Console.ReadLine()[0]);

        // Switch statement to match grade value
        switch (grade)
        {
            case 'E':   // If grade is E
                Console.WriteLine("Excellent");
                break;

            case 'V':   // If grade is V
                Console.WriteLine("Very Good");
                break;

            case 'G':   // If grade is G
                Console.WriteLine("Good");
                break;

            case 'A':   // If grade is A
                Console.WriteLine("Average");
                break;

            case 'F':   // If grade is F
                Console.WriteLine("Fail");
                break;

            default:    // If grade does not match any case
                Console.WriteLine("Invalid Grade");
                break;
        }
    }
}
