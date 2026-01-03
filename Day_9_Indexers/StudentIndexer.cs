// Import System namespace for Console
using System;

// Namespace groups related classes
namespace Day9_StudentIndexers
{
    // -------------------------------------------------
    // Student class
    // Demonstrates:
    // - Public properties
    // - Private field
    // - Constructor with parameters
    // - Params keyword
    // - Indexer
    // -------------------------------------------------
    class Student
    {
        // -------------------------
        // Public properties
        // -------------------------

        // Roll number (public get & set)
        public int Rno { get; set; }

        // Student name (nullable string)
        public string? Name { get; set; }

        // -------------------------
        // Private field
        // -------------------------
        // Address is private → cannot be accessed directly from outside
        private string? Address;

        // Private array to store books
        private string[] books;

        // -------------------------
        // Constructor
        // -------------------------
        // params allows passing variable number of book names
        public Student(int rno, string name, string address, params string[] initialBooks)
        {
            Rno = rno;              // Assign roll number
            Name = name;            // Assign name
            Address = address;      // Assign private address
            books = initialBooks;   // Assign books array
        }

        // -------------------------
        // INDEXER
        // -------------------------
        // Allows accessing books like:
        // student[0], student[1], etc.
        public string this[int index]
        {
            // Getter → when reading book
            get
            {
                // Check index is valid
                if (index >= 0 && index < books.Length)
                    return books[index];
                else
                    return "Invalid book index";
            }

            // Setter → when modifying book
            set
            {
                if (index >= 0 && index < books.Length)
                {
                    books[index] = value;
                }
                else
                {
                    Console.WriteLine("Cannot set book: Index is out of range.");
                }
            }
        }

        // -------------------------
        // Public method to access private address
        // -------------------------
        public void DisplayAddress()
        {
            Console.WriteLine($"Address: {Address}");
        }
    }

    // -------------------------------------------------
    // Main class
    // Program execution starts here
    // -------------------------------------------------
    class StudentIndexer
    {
        static void Main(string[] args)
        {
            // Creating Student object
            Student student1 = new Student(
                1,
                "Alice Smith",
                "123 Main St, City, Country",
                "Calculus Textbook",
                "Physics Handbook",
                "History of the World"
            );

            // Access public property
            Console.WriteLine($"Student Name: {student1.Name}");

            // Access private field through public method
            student1.DisplayAddress();

            // -------------------------
            // Access books using indexer
            // -------------------------
            Console.WriteLine($"Book 1: {student1[0]}");
            Console.WriteLine($"Book 2: {student1[1]}");
            Console.WriteLine($"Book 3: {student1[2]}");

            // Modify a book using indexer
            student1[1] = "Advanced Physics Handbook";

            Console.WriteLine($"Updated Book 2: {student1[1]}");
        }
    }
}
