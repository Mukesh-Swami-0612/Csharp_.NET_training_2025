// Problem: Demonstrate method overriding

using System;
// Using System namespace to access Console class

// Base (parent) class
public class Father
{
    // Virtual method
    // This method can be overridden in a child class
    public virtual string Interest()
    {
        return "Cricket";
    }
}

// Child class inheriting from Father
public class Son : Father
{
    // Overriding the virtual method of the parent class
    // 'override' keyword ensures runtime polymorphism
    public override string Interest()
    {
        return "Mobile Games";
    }
}

// Main program class
class Program
{
    public static void Main()
    {
        // Upcasting:
        // Father reference pointing to Son object
        Father f = new Son();

        // Runtime polymorphism:
        // Son's Interest() method is called, not Father's
        Console.WriteLine(f.Interest());
    }
}
