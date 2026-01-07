using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

// Person class
public class Person
{
    public int Id { get; set; }          // ID property
    public string Name { get; set; } = ""; // Name property
    public int Age { get; set; }         // Age property

    // Integer array
    public int[] MarksArray { get; set; }

    // Integer list
    public List<int> MarksList { get; set; }
}

class Program
{
    static void Main()
    {
        // Create object
        Person p = new Person();

        // Assign values
        p.Id = 1;
        p.Name = "Mukesh";
        p.Age = 22;

        // Initialize array
        p.MarksArray = new int[] { 10, 20, 30 };

        // Initialize list
        p.MarksList = new List<int> { 40, 50, 60 };

        // Create serializer
        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        // Create StringWriter
        StringWriter writer = new StringWriter();

        // Serialize object
        serializer.Serialize(writer, p);

        // Print XML
        Console.WriteLine(writer.ToString());
    }
}
