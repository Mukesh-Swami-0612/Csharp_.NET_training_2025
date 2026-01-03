using System;

namespace Visitor
{
    // Veg Interface
    public interface IVeg
    {
        void Iveg();
        string GetTaste();
    }

    // Non-Veg Interface
    internal interface NonVeg
    {
        void Nonveg();
        string GetTaste();
    }

    // Class implementing both interfaces
    public class Fooddiee : IVeg, NonVeg
    {
        // Normal method implementation
        public void Iveg()
        {
            Console.WriteLine("I am Veg");
        }

        public void Nonveg()
        {
            Console.WriteLine("I am Non-Veg");
        }

        // Explicit interface implementation
        string IVeg.GetTaste()
        {
            return "Amazing";
        }

        string NonVeg.GetTaste()
        {
            return "Good";
        }
    }

    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calling Veg interface method
            IVeg iv = new Fooddiee();
            string vTaste = iv.GetTaste();
            Console.WriteLine("Veg Taste: " + vTaste);

            // Calling Non-Veg interface method
            NonVeg nv = new Fooddiee();
            string nvTaste = nv.GetTaste();
            Console.WriteLine("Non-Veg Taste: " + nvTaste);

            Console.WriteLine("Foodie!");

            // Calling normal class methods
            Fooddiee f1 = new Fooddiee();
            f1.Iveg();
            f1.Nonveg();
        }
    }
}
