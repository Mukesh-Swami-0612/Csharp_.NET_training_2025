
// Question:
// Input grade (E, V, G, A, F) and print description

using System;

class GradeDescription
{
    static void Main()
    {
        Console.Write("Enter grade (E/V/G/A/F): ");
        char grade = char.ToUpper(Console.ReadLine()[0]);

        switch (grade)
        {
            case 'E':
                Console.WriteLine("Excellent");
                break;
            case 'V':
                Console.WriteLine("Very Good");
                break;
            case 'G':
                Console.WriteLine("Good");
                break;
            case 'A':
                Console.WriteLine("Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid Grade");
                break;
        }
    }
}
