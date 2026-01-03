// Question:
// Calculate profit or loss percentage

using System;
// Using System namespace for Console input/output

class ProfitLoss
{
    // Program execution starts from Main method
    static void Main()
    {
        // Ask user to enter Cost Price (CP)
        Console.Write("Enter Cost Price: ");
        double cp = double.Parse(Console.ReadLine());

        // Ask user to enter Selling Price (SP)
        Console.Write("Enter Selling Price: ");
        double sp = double.Parse(Console.ReadLine());

        // If selling price is greater than cost price → Profit
        if (sp > cp)
        {
            // Calculate profit amount
            double profit = sp - cp;

            // Calculate and print profit percentage
            Console.WriteLine("Profit % = " + (profit / cp) * 100);
        }
        // If cost price is greater than selling price → Loss
        else if (cp > sp)
        {
            // Calculate loss amount
            double loss = cp - sp;

            // Calculate and print loss percentage
            Console.WriteLine("Loss % = " + (loss / cp) * 100);
        }
        // If both prices are equal
        else
        {
            Console.WriteLine("No Profit No Loss");
        }
    }
}
