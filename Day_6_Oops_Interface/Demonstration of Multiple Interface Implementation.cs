using System;

// Namespace groups related classes and interfaces together
namespace Visitor
{
    // Interface for Veg food
    // Interface only contains method declarations
    public interface IVeg
    {
        void Iveg();   // Veg method
    }

    // Interface for Non-Veg food
    public interface NonVeg
    {
        void Nonveg(); // Non-Veg method
    }

    // Fooddiee class implements both IVeg and NonVeg interfaces
    public class Fooddiee : IVeg, NonVeg
    {
        // Implementation of IVeg interface method
        public void Iveg()
        {
            Console.WriteLine("I am Veg");
        }

        // Implementation of NonVeg interface method
        public void Nonveg()
        {
            Console.WriteLine("I am Non-Veg");
        }
    }

    // Program class - execution starts from Main method
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Foodie!");

            // Creating object of Fooddiee class
            Fooddiee f1 = new Fooddiee();

            // Calling Veg method
            f1.Iveg();

            // Calling Non-Veg method
            f1.Nonveg();

            // Pause console
            Console.ReadLine();
        }
    }
}
