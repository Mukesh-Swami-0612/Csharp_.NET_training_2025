using System;

namespace LibrarySystem.Items
{
    // Magazine inherits LibraryItem
    public class Magazine : LibraryItem
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Magazine");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        // Magazine late fee = 0.5 per day
        public override double CalculateLateFee(int days)
        {
            return days * 0.5;
        }
    }
}

