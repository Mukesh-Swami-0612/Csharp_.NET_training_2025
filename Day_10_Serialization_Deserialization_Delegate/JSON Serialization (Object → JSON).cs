using System;
using System.Text.Json;

// Person class
public class Person
{
    public int Id { get; set; }      // ID property
    public string Name { get; set; } = ""; // Name property
    public int Age { get; set; }     // Age property
}

class Program
{
    static void Main()
    {
        // Create object using object initializer
        Person p = new Person
        {
            Id = 1,
            Name = "Mukesh",
            Age = 22
        };

        // Serialize object to JSON
        string json = JsonSerializer.Serialize(p);

        // Print JSON
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
    }
}
