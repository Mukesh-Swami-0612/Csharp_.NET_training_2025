// Problem: Demonstrate inheritance and polymorphism

using System;
// Using System namespace to access Console and basic .NET classes

// Base class (Parent class)
public class Person
{
    // Common properties for all persons
    public int Id;
    public string Name;
    public int Age;
}

// Man class inherits from Person
public class Man : Person
{
    // Extra property specific to Man
    public string Playing;
}

// Woman class inherits from Person
public class Woman : Person
{
    // Extra property specific to Woman
    public string Managing;
}

class Program
{
    // This method accepts a Person reference (polymorphism)
    static string GetDetails(Person p)
    {
        // If the object is of type Man
        if (p is Man m)
            return $"Man: {m.Name}, Playing: {m.Playing}";

        // If the object is of type Woman
        if (p is Woman w)
            return $"Woman: {w.Name}, Managing: {w.Managing}";

        // If object type is unknown
        return "Unknown";
    }

    static void Main()
    {
        // Upcasting:
        // Person reference pointing to Man object
        Person p1 = new Man { Name = "Mukesh", Playing = "Cricket" };

        // Person reference pointing to Woman object
        Person p2 = new Woman { Name = "Renu", Managing = "Team" };

        // Polymorphic behavior:
        // Same method, different output based on object type
        Console.WriteLine(GetDetails(p1));
        Console.WriteLine(GetDetails(p2));
    }
}
