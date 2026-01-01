// Import System namespace for Console and basic features
using System;

// Namespace name (just a logical grouping)
namespace Day9_IndexerExample
{
    // ---------------------------------------
    // MyObj class
    // This class demonstrates INDEXER concept
    // ---------------------------------------
    class MyObj
    {
        // Private array to store values internally
        // Size is fixed to 3
        private string[] values = new string[3];

        // -------------------------------
        // INDEXER
        // -------------------------------
        // This allows object to be accessed like an array
        // Example: obj[0], obj[1], obj[2]
        public string this[int index]
        {
            // Getter → runs when we READ data (obj[index])
            get
            {
                return values[index];
            }

            // Setter → runs when we ASSIGN data (obj[index] = value)
            set
            {
                values[index] = value;
            }
        }
    }

    // ---------------------------------------
    // Main class
    // Program execution starts from Main()
    // ---------------------------------------
    class Indexers
    {
        public static void Main()
        {
            // Creating object of MyObj class
            // new() is shorthand for new MyObj()
            MyObj obj = new();

            // Using indexer to SET values
            obj[0] = "C#";
            obj[1] = "C++";
            obj[2] = "Java";

            // Using indexer to GET values
            Console.WriteLine("First index: " + obj[0]);
            Console.WriteLine("Second index: " + obj[1]);
            Console.WriteLine("Third index: " + obj[2]);
        }
    }
}
