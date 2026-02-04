
using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                int result = bonus / salaries[i];
                Console.WriteLine("Employee " + (i + 1) + " Bonus: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Employee " + (i + 1) + " Error: Salary is zero.");
            }
        }

        Console.WriteLine("Processing Completed.");
    }
}
