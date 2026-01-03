using System;
using LibrarySystem.Interfaces;

namespace LibrarySystem.Items
{
    // Book inherits LibraryItem and implements interfaces
    public class Book : LibraryItem, IReservable, INotifiable
    {
        // Override abstract method
        public override void DisplayItemDetails()
        {
            Console.WriteLine("Item Type: Book");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Item ID: {ItemID}");
        }

        // Book late fee = 1 unit per day
        public override double CalculateLateFee(int days)
        {
            return days * 1.0;
        }

        // Explicit interface implementation
        void IReservable.Reserve()
        {
            Console.WriteLine("Book reserved successfully.");
        }

        void INotifiable.Notify(string message)
        {
            Console.WriteLine("Notification: " + message);
        }
    }
}

