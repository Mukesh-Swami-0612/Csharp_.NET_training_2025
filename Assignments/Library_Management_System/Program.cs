using System;
using System.Collections.Generic;
using LibrarySystem.Items;
using LibrarySystem.Users;
using LibrarySystem.Interfaces;
using LibrarySystem.Analytics;
// Namespace alias
using ItemsAlias = LibrarySystem.Items;

namespace LibrarySystem
{
    class Program
    {
        static void Main()
        {
            // TASK 1 PROOF
            Book book = new Book
            {
                Title = "C# Fundamentals",
                Author = "John Doe",
                ItemID = 101
            };

            Magazine magazine = new Magazine
            {
                Title = "Tech Today",
                Author = "Jane Doe",
                ItemID = 201
            };

            book.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + book.CalculateLateFee(3));
            Console.WriteLine();

            magazine.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + magazine.CalculateLateFee(3));
            Console.WriteLine();

            // TASK 2 & 4 PROOF (Explicit Interface)
            IReservable reservable = book;
            reservable.Reserve();
            INotifiable notifiable = book;
            notifiable.Notify("Please return the book on time.");
            Console.WriteLine();

            // TASK 3 – Dynamic Polymorphism
            List<LibraryItem> items = new List<LibraryItem>();
            items.Add(book);
            items.Add(magazine);

            foreach (LibraryItem item in items)
            {
                item.DisplayItemDetails();
            }

            Console.WriteLine("Explanation: Method selection happens at runtime.");
            Console.WriteLine();

            // TASK 5 – Namespace Alias
            ItemsAlias.Book b2 = new ItemsAlias.Book();
            ItemsAlias.Magazine m2 = new ItemsAlias.Magazine();
            Console.WriteLine("Objects created using namespace alias.");
            Console.WriteLine();

            // TASK 6 – Static & Partial
            LibraryAnalytics.TotalBorrowedItems = 5;
            LibraryAnalytics.ShowAnalytics();
            Console.WriteLine();

            // TASK 7 – Enums
            Member user = new Member { Name = "Mukesh", Role = UserRole.Member };
            ItemStatus status = ItemStatus.Borrowed;

            Console.WriteLine("User Role: " + user.Role);
            Console.WriteLine("Item Status: " + status);
            Console.WriteLine();

            // BONUS – Role Based Notification
            if (user.Role == UserRole.Admin)
                Console.WriteLine("Admin Alert: System maintenance scheduled.");
            else
                Console.WriteLine("Member Notification: Your borrowed item is due tomorrow.");

            // BONUS – eBook
            eBook ebook = new eBook
            {
                Title = "Learn C# Online",
                Author = "Digital Author",
                ItemID = 301
            };
            ebook.Download();
        }
    }
}

