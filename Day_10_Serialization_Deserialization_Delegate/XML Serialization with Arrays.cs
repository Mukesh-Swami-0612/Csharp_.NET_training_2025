// Import System namespace (basic C# classes like Console)
using System;

// Import IO namespace (for StringWriter)
using System.IO;

// Import XML Serialization namespace
using System.Xml.Serialization;

// Person class (this will be serialized into XML)
public class Person
{
    // Property to store ID
    public int Id { get; set; }

    // Property to store Name
    public string Name { get; set; } = "";

    // Property to store Age
    public int Age { get; set; }

    // Integer array property
    public int[] Marks { get; set; }

    // Another integer array property
    public int[] Marks1 { get; set; }
}

// Program class
class Program
{
    // Main method (program starts here)
    static void Main()
    {
        // Create Person object
        Person p = new Person();

        // Assign values
        p.Id = 1;
        p.Name = "Mukesh";
        p.Age = 22;

        // Initialize arrays
        p.Marks = new int[] { 1, 2, 3, 4, 5 };
        p.Marks1 = new int[] { 11, 22, 33, 44, 55 };

        // Create XmlSerializer object for Person class
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        // Create StringWriter to hold XML output
        StringWriter writer = new StringWriter();

        // Serialize object into XML
        serializer.Serialize(writer, p);

        // Print XML output
        Console.WriteLine(writer.ToString());
    }
}
