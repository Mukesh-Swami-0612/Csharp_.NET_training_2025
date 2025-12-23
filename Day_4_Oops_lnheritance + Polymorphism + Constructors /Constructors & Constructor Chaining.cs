// Problem: Demonstrate constructor chaining

using System;
// Using System namespace to access Console class

// Visitor class
public class Visitor
{
    // Field to store visitor ID
    public int Id;

    // Field to store visitor Name
    public string Name;

    // Field to store constructor call history
    public string Log = "";

    // Default constructor (no parameters)
    public Visitor()
    {
        // Add message when default constructor is called
        Log += "Default constructor called\n";
    }

    // Constructor with one parameter (Id)
    // 'this()' calls the default constructor first
    public Visitor(int id) : this()
    {
        // Assign Id value
        Id = id;

        // Add message when Id constructor is called
        Log += "Id constructor called\n";
    }

    // Constructor with two parameters (Id and Name)
    // 'this(id)' calls the constructor with one parameter
    public Visitor(int id, string name) : this(id)
    {
        // Assign Name value
        Name = name;

        // Add message when Name constructor is called
        Log += "Name constructor called\n";
    }
}

// Main program class
class Program
{
    // Program execution starts from Main method
    public static void Main()
    {
        // Creating Visitor object using 2-parameter constructor
        Visitor v = new Visitor(1, "Mukesh");

        // Printing the order in which constructors were executed
        Console.WriteLine(v.Log);
    }
}
