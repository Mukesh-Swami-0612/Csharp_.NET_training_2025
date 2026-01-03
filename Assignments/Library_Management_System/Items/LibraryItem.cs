using System;

namespace LibrarySystem.Items
{
    // Abstract base class
    public abstract class LibraryItem
    {
        // Exactly 3 properties
        public string Title { get; set; }
        public string Author { get; set; }
        public int ItemID { get; set; }

        // Exactly 2 abstract methods
        public abstract void DisplayItemDetails();
        public abstract double CalculateLateFee(int days);
    }
}

