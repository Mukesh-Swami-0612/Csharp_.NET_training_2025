
// Question:
// Calculate profit or loss percentage

using System;

class ProfitLoss
{
    static void Main()
    {
        Console.Write("Enter Cost Price: ");
        double cp = double.Parse(Console.ReadLine());

        Console.Write("Enter Selling Price: ");
        double sp = double.Parse(Console.ReadLine());

        if (sp > cp)
        {
            double profit = sp - cp;
            Console.WriteLine("Profit % = " + (profit / cp) * 100);
        }
        else if (cp > sp)
        {
            double loss = cp - sp;
            Console.WriteLine("Loss % = " + (loss / cp) * 100);
        }
        else
        {
            Console.WriteLine("No Profit No Loss");
        }
    }
}
