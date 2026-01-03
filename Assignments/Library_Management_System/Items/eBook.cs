using System;

namespace LibrarySystem.Items
{
    public class eBook : LibraryItem
    {
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: eBook");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        public override double CalculateLateFee(int days)
        {
            return 0; // No late fee for eBook
        }

        // Digital specific behavior
        public void Download()
        {
            Console.WriteLine("eBook downloaded successfully.");
        }
    }
}

