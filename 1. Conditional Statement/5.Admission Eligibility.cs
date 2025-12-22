
Admission Eligibility: Math ≥ 65, Phys ≥ 55, Chem ≥ 50 AND (Total ≥ 180 OR Math+Phys ≥ 140).

using System;   // Imports System namespace to use Console class

// This program checks whether a student is eligible for admission
// based on marks in Maths, Physics, and Chemistry
class AdmissionEligibility
{
    // Main method: program execution starts here
    public static void Main(string[] args)
    {
        // Ask the user to enter Maths marks
        Console.Write("Enter Maths marks: ");
        double M = double.Parse(Console.ReadLine());
        // double is used because marks can be decimal

        // Ask the user to enter Physics marks
        Console.Write("Enter Physics marks: ");
        double P = double.Parse(Console.ReadLine());

        // Ask the user to enter Chemistry marks
        Console.Write("Enter Chemistry marks: ");
        double C = double.Parse(Console.ReadLine());

        // Calculate total marks of all three subjects
        double total = M + P + C;

        // Calculate total marks of Maths and Physics only
        double MP = M + P;

        // Eligibility conditions:
        // 1. Maths >= 65
        // 2. Physics >= 55
        // 3. Chemistry >= 50
        // 4. Either total >= 180 OR Maths + Physics >= 140
        if (M >= 65 && P >= 55 && C >= 50 && (total >= 180 || MP >= 140))
        {
            // Student satisfies all eligibility conditions
            Console.WriteLine("Eligible for admission");
        }
        else
        {
            // Student does not satisfy eligibility conditions
            Console.WriteLine("Not Eligible");
        }
    }
}

