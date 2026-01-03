

// Problem:
// Electricity Bill:
// First 199 units @ 1.20
// 200–400 units @ 1.50
// 400–600 units @ 1.80
// Above 600 units @ 2.00
// Add 15% surcharge if bill > 400


using System;
class ElectricityBill
{
    static void Main()
    {
        Console.Write("Enter units consumed: ");
        int units = int.Parse(Console.ReadLine());

        double bill = 0;

        // Calculate bill based on unit slabs
        if (units <= 199)
        {
            bill = units * 1.20;
        }
        else if (units <= 400)
        {
            bill = (199 * 1.20) + ((units - 199) * 1.50);
        }
        else if (units <= 600)
        {
            bill = (199 * 1.20) + (201 * 1.50) + ((units - 400) * 1.80);
        }
        else
        {
            bill = (199 * 1.20) + (201 * 1.50) + (200 * 1.80) + ((units - 600) * 2.00);
        }

        // Add surcharge if bill > 400
        if (bill > 400)
        {
            bill = bill + (bill * 0.15);
        }

        Console.WriteLine("Total Electricity Bill = " + bill);
    }
}
