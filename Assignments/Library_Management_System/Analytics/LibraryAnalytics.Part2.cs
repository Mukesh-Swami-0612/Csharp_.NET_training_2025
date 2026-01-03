using System;

namespace LibrarySystem.Analytics
{
    public partial class LibraryAnalytics
    {
        public static void ShowAnalytics()
        {
            Console.WriteLine("Total Items Borrowed: " + TotalBorrowedItems);
        }
    }
}

