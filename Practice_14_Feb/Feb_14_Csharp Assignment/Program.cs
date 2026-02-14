using System;

namespace BookStoreApp
{
    public class InvalidBookDataException : Exception
    {
        public InvalidBookDataException(string message) : base(message) { }
    }

    public class Book
    {
        public string Id { get; }
        public string Title { get; }

        private int price;
        public int Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new InvalidBookDataException("Price cannot be negative.");
                price = value;
            }
        }

        private int stock;
        public int Stock
        {
            get => stock;
            set
            {
                if (value < 0)
                    throw new InvalidBookDataException("Stock cannot be negative.");
                stock = value;
            }
        }

        public Book(string id, string title, int price, int stock)
        {
            Id = id;
            Title = title;
            Price = price;
            Stock = stock;
        }
    }

    public class BookUtility
    {
        private readonly Book book;

        public BookUtility(Book book)
        {
            this.book = book;
        }

        public void GetBookDetails()
        {
            Console.WriteLine($"\nDetails: {book.Id} {book.Title} {book.Price} {book.Stock}");
        }

        public void UpdateBookPrice()
        {
            Console.Write("Enter new price: ");
            int newPrice = int.Parse(Console.ReadLine());
            book.Price = newPrice;
            Console.WriteLine($"Updated Price: {book.Price}");
        }

        public void UpdateBookStock()
        {
            Console.Write("Enter new stock: ");
            int newStock = int.Parse(Console.ReadLine());
            book.Stock = newStock;
            Console.WriteLine($"Updated Stock: {book.Stock}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("=== Welcome to Book Store Application ===\n");

                Console.Write("Enter Book ID: ");
                string id = Console.ReadLine();

                Console.Write("Enter Book Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Book Price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter Book Stock: ");
                int stock = int.Parse(Console.ReadLine());

                Book book = new Book(id, title, price, stock);
                BookUtility utility = new BookUtility(book);

                while (true)
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Display Book Details");
                    Console.WriteLine("2. Update Book Price");
                    Console.WriteLine("3. Update Book Stock");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            utility.GetBookDetails();
                            break;

                        case 2:
                            utility.UpdateBookPrice();
                            break;

                        case 3:
                            utility.UpdateBookStock();
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice. Try again.");
                            break;
                    }
                }
            }
            catch (InvalidBookDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input. Please enter correct data.");
            }
        }
    }
}
